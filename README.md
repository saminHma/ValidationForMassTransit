## 📚 Validation Library for MassTransit

This library provides a powerful validation mechanism for MassTransit, leveraging the flexibility of FluentValidation. With this library, you can easily validate queries, commands, and models according to your specific requirements without the need to set validation for all events declared in the statemachine.

### Features
- Seamlessly integrate with MassTransit and FluentValidation.
- Validate queries, commands, and models according to custom rules.
- Solve the issue of having to set validation for all events declared in the statemachine.

### Installation
To use this library, simply add it to your project's dependencies and you can see my project that use this libarary for validation in the [[documentation link](https://github.com/saminHma/MassTransitSign/blob/master/Validation)]. 

### Usage
Below is an example of how to use the library for validating in project:
```csharp
// use some services in program.cs
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IValidationFailurePipe<>), typeof(ValidationFailurePipe<>));

builder.Services.AddMassTransit(x =>
{
    x.UsingInMemory((context, cfg) =>
    {
        cfg.UseConsumeFilter(typeof(ValidationForMassTransit.FluentValidationFilter<>), context);        
    }); 
});
```

### Contributing
Contributions are welcome! If you'd like to contribute to this project.


### Acknowledgements
We'd like to express our gratitude to the creators of MassTransit and FluentValidation for their exceptional work, which has made this library possible.

Feel free to reach out if you have any questions or need assistance with the library. Happy validating! 🚀



