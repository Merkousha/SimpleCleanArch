using FluentValidation;
using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Validators
{
    public class AuthorUpdateDtoValidator : AbstractValidator<AuthorUpdateDto>
    {
        public AuthorUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Biography)
                .NotEmpty()
                .WithMessage("Biography is required")
                .MaximumLength(2000)
                .WithMessage("Biography cannot exceed 2000 characters");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Birth date is required")
                .LessThan(System.DateTime.Now)
                .WithMessage("Birth date must be in the past");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(500)
                .WithMessage("Image URL cannot exceed 500 characters");

            RuleFor(x => x.Country)
                .MaximumLength(100)
                .WithMessage("Country cannot exceed 100 characters");
        }
    }
} 