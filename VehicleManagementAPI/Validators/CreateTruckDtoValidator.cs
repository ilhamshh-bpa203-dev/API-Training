using FluentValidation;
using VehicleManagementAPI.DTOs;

namespace VehicleManagementAPI.Validators
{
    public class CreateTruckDtoValidator:AbstractValidator<CreateTruckDto>
    {
        public CreateTruckDtoValidator()
        {
            RuleFor(x=>x.CargoCapacity)
                .NotEmpty().WithMessage("Can't be empty..")
                .Must(x=>x>0).WithMessage("Can't be negative..")
                ;
            RuleFor(x=>x.AxleCount  )
                .NotEmpty().WithMessage("Can't be empty..")
                .Must(x=>x>0).WithMessage("Can't be negative..")
                ;
            RuleFor(x=>x.CurrentLoad)
                .NotEmpty().WithMessage("Can't be empty..")
                .GreaterThanOrEqualTo(0).WithMessage("Can't be negative..")
                .LessThanOrEqualTo(x=>x.CargoCapacity).WithMessage("Can't be more than Cargo capacity..")
                ;
        }
    }
}
