using MassTransit;

namespace ValidationForMassTransit;

/// <summary>
/// Extension methods for injecting functionality from the <see cref="FluentValidation"/> library into a <see cref="MassTransit"/> pipeline.
/// </summary>
//public static class FluentValidationExtensions
//{
//    public static IEndpointConfigurator UseFluentValidationForMassTransit(this IEndpointConfigurator configurator, IBusRegistrationContext context)
//    {
//        configurator.UseConsumeFilter(typeof(FluentValidationFilter<>), context);
//        return configurator;
//    }
//}
