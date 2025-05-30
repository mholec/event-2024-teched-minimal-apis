var builder = WebApplication.CreateBuilder(args);

// infrastructure services
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// exception handling
builder.Services.AddProblemDetails(ProblemDetailsConfiguration.Configure());
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GeneralExceptionHandler>();

// application pipeline
var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

app.RegisterApiRoutes();

app.Run();