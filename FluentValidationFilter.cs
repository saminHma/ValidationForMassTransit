using MassTransit;

namespace ValidationForMassTransit;

public class FluentValidationFilter<TMessage> : IFilter<ConsumeContext<TMessage>> where TMessage : class
{
    private readonly IValidationFailurePipe<TMessage> _failurePipe;
    private readonly IEnumerable<IValidator<TMessage>> _validators;

    public FluentValidationFilter(IEnumerable<IValidator<TMessage>> validator, IValidationFailurePipe<TMessage> failurePipe)
    {
        _validators = validator;
        _failurePipe = failurePipe ?? throw new ArgumentNullException(nameof(failurePipe));
    }

    public async Task Send(ConsumeContext<TMessage> context, IPipe<ConsumeContext<TMessage>> next)
    {
        if (!_validators.Any())
        {
            await next.Send(context);
            return;
        }

        var validationResults = await Task.WhenAll(
            _validators.Select(v =>
                v.ValidateAsync(context.Message)));

        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        if (!failures.Any())
        {
            await next.Send(context);
            return;
        }


        var validationProblems = validationResults.SelectMany(r => r.Errors).ToErrorDictionary();

        var failureContext = new ValidationFailureContext<TMessage>(context, validationProblems);
        await _failurePipe.Send(failureContext);
    }
    public void Probe(ProbeContext context)
    {
        context.CreateScope("FluentValidationFilter");
    }
}
