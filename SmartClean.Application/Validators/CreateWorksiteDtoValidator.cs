using FluentValidation;
using SmartClean.Application.DTOs;

namespace SmartClean.Application.Validators
{
    public class CreateWorksiteDtoValidator : AbstractValidator<CreateWorksiteDto>
    {
        public CreateWorksiteDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID is required")
                .MaximumLength(10).WithMessage("ID cannot exceed 10 characters")
                .Matches("^[A-Z0-9]+$").WithMessage("ID must contain only uppercase letters and numbers");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters");

            RuleFor(x => x.City)
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters");

            RuleFor(x => x.PostalCode)
                .MaximumLength(20).WithMessage("Postal code cannot exceed 20 characters");

            RuleFor(x => x.ContactPerson)
                .MaximumLength(50).WithMessage("Contact person cannot exceed 50 characters");

            RuleFor(x => x.ContactPhone)
                .MaximumLength(20).WithMessage("Contact phone cannot exceed 20 characters");

            RuleFor(x => x.ContactEmail)
                .EmailAddress().WithMessage("Invalid email format")
                .MaximumLength(100).WithMessage("Contact email cannot exceed 100 characters");

            RuleFor(x => x.SquareFootage)
                .GreaterThan(0).WithMessage("Square footage must be greater than 0");

            RuleFor(x => x.NumberOfRooms)
                .GreaterThanOrEqualTo(0).WithMessage("Number of rooms cannot be negative");

            RuleFor(x => x.NumberOfBathrooms)
                .GreaterThanOrEqualTo(0).WithMessage("Number of bathrooms cannot be negative");

            RuleFor(x => x.NumberOfKitchens)
                .GreaterThanOrEqualTo(0).WithMessage("Number of kitchens cannot be negative");

            RuleFor(x => x.ToiletCount)
                .GreaterThanOrEqualTo(0).WithMessage("Toilet count cannot be negative");

            RuleFor(x => x.HandwashCount)
                .GreaterThanOrEqualTo(0).WithMessage("Handwash count cannot be negative");

            RuleFor(x => x.SpecialRequirements)
                .MaximumLength(500).WithMessage("Special requirements cannot exceed 500 characters");

            RuleFor(x => x.ParentId)
                .MaximumLength(10).WithMessage("Parent ID cannot exceed 10 characters")
                .Matches("^[A-Z0-9]*$").WithMessage("Parent ID must contain only uppercase letters and numbers");
        }
    }
}
