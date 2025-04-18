using FluentValidation;
using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Validators
{
    public class AuthorDtoValidator : AbstractValidator<AuthorDto>
    {
        public AuthorDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug is required")
                .MaximumLength(100).WithMessage("Slug cannot exceed 100 characters")
                .Matches("^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("Slug must be in valid format (lowercase letters, numbers, and hyphens)");
        }
    }
}