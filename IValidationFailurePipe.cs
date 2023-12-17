using MassTransit;

namespace ValidationForMassTransit;

public interface IValidationFailurePipe<TMessage> :
    IPipe<ValidationFailureContext<TMessage>>
    where TMessage : class
{ }