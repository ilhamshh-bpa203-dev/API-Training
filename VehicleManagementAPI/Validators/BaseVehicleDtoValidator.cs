using FluentValidation;
using VehicleManagementAPI.DTOs;

namespace VehicleManagementAPI.Validators
{
    public class BaseVehicleDtoValidator : AbstractValidator<BaseVehicleDto>
    {
        public BaseVehicleDtoValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Can't be empty..")
                ;

            RuleFor(x => x.PlateNumber)
                .NotEmpty().WithMessage("Can't be empty..")
                ;

            RuleFor(x => x.Year)
                .NotEmpty().WithMessage("Can't be empty..")
                .InclusiveBetween(1886, DateTime.Now.Year)
                .WithMessage($"Year must be between 1886 and {DateTime.Now.Year}..")
                ;

            RuleFor(x => x.FuelLevel)
                .NotEmpty().WithMessage("Can't be empty..")
                .Must(x => x >= 0 && x <= 100).WithMessage("Fuel level must be between 0 and 100...")
                ;

            RuleFor(x => x.MaxSpeed)
                .NotEmpty().WithMessage("Can't be empty..")
                .Must(x => x > 0).WithMessage("Can't be negative..")
                ;
        }
    }
}
