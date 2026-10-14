using FluentValidation;
using VehicleManagementAPI.DTOs;

namespace VehicleManagementAPI.Validators
{
    public class CreateCarDtoValidator:AbstractValidator<CreateCarDto>
    {
        public CreateCarDtoValidator()
        {
            Include(new BaseVehicleDtoValidator());

            RuleFor(x => x.DoorsCount)
                .NotEmpty().WithMessage("Can't be empty..")
                .Must(x=> x>0).WithMessage("Can't be negative..")
                ;
            RuleFor(x => x.TrunkCapacity)
                .NotEmpty().WithMessage("Can't be empty..")
                .Must(x=>x>0).WithMessage("Can't be negative..")
                ;
            
            
        }
    }
}
