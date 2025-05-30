using FluentValidation.Results;

namespace BigMinimal.Advanced.Validation;

public class ValidationBehavior<TRequest, TResult> :
    IPipelineBehavior<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken ctn)
    {
        List<ValidationFailure> errors = new();
        foreach (var validator in _validators)
        {
            var result = await validator.ValidateAsync(request, ctn);
            errors.AddRange(result.Errors);
        }

        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next();
    }
}