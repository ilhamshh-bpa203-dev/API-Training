using FluentValidation;
using VehicleManagementAPI.DTOs;
using VehicleManagementAPI.Utilities.Enums;

namespace VehicleManagementAPI.Validators
{
    public class CreateMotorcycleDtoValidator : AbstractValidator<CreateMotorcycleDto>
    {
        public CreateMotorcycleDtoValidator()
        {
            Include(new BaseVehicleDtoValidator());



            RuleFor(x => x.EngineCapacity)
                .NotEmpty().WithMessage("Can't be empty..")
                .Must(x => x > 0).WithMessage("Can't be negative..")
                ;
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Can't be empty..")
                .IsInEnum().WithMessage($"Motorcycle type must be one of them:"
                + $"{string.Join(",",Enum.GetNames(typeof(MotorcycleType)))}"
                );
            ;
        }
    }
}
