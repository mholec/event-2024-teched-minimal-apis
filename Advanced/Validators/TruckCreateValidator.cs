using BigMinimal.Advanced.Contracts;
using BigMinimal.Advanced.Handlers.Trucks;

namespace BigMinimal.Advanced.Validation;

public class TruckCreateValidator : AbstractValidator<CreateTruckRequest>
{
    public TruckCreateValidator()
    {
        RuleFor(x => x.Truck.Name).NotNull().OverridePropertyName(nameof(TruckCreate.Name));
        RuleFor(x => x.Truck.Price).NotNull().GreaterThan(0).OverridePropertyName(nameof(TruckCreate.Price));
        RuleFor(x => x.Truck.Registration).NotNull().GreaterThan(new DateTime(2023, 1, 1)).OverridePropertyName(nameof(TruckCreate.Registration));
    }
}