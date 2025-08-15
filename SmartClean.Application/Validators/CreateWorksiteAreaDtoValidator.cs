using FluentValidation;
using SmartClean.Application.DTOs;

namespace SmartClean.Application.Validators
{
    public class CreateWorksiteAreaDtoValidator : AbstractValidator<CreateWorksiteAreaDto>
    {
        public CreateWorksiteAreaDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required")
                .MaximumLength(10).WithMessage("ID cannot exceed 10 characters")
                .Matches("^[A-Z0-9]+$").WithMessage("ID must contain only uppercase letters and numbers");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.Priority)
                .GreaterThan(0).WithMessage("Priority must be greater than 0");

            RuleFor(x => x.EstimatedCleaningTimeMinutes)
                .GreaterThan(0).WithMessage("Estimated cleaning time must be greater than 0");

            RuleFor(x => x.RequiredStaffCount)
                .GreaterThan(0).WithMessage("Required staff count must be greater than 0");

            RuleFor(x => x.CleaningInstructions)
                .MaximumLength(1000).WithMessage("Cleaning instructions cannot exceed 1000 characters");

            RuleFor(x => x.RequiredEquipment)
                .MaximumLength(500).WithMessage("Required equipment cannot exceed 500 characters");

            RuleFor(x => x.RequiredSupplies)
                .MaximumLength(500).WithMessage("Required supplies cannot exceed 500 characters");

            RuleFor(x => x.WorksiteId)
                .NotEmpty().WithMessage("Worksite ID is required")
                .MaximumLength(10).WithMessage("Worksite ID cannot exceed 10 characters")
                .Matches("^[A-Z0-9]+$").WithMessage("Worksite ID must contain only uppercase letters and numbers");
        }
    }
}
