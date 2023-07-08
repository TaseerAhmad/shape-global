using FluentValidation;
using ShapeServer.Models.DTO.SignupRequest;

namespace ShapeServer.Models.Validations
{
    public class SignupValidator : AbstractValidator<SignupRequest>
    {
        public SignupValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(12)
                .WithMessage("First name must not exceed 12 characters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(16)
                .WithMessage("Last name must not exceed 16 characters");

            RuleFor(x => x.Email)
                .EmailAddress()
                .Must(HasValidTLD)
                .WithMessage("Invalid Email address");

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$")
                .WithMessage("Password must have at least 1 upper, 1 lower, 1 number and 1 special character and at least 8 characters long");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password)
                .OverridePropertyName(x => x.Password)
                .WithMessage("Passwords are not equal");
        }

        private bool HasValidTLD(string email)
        {
            return email.EndsWith(".com");
        }
    }
}
