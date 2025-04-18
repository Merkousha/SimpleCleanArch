using FluentValidation;
using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Validators
{
    public class KeywordCreateDtoValidator : AbstractValidator<KeywordCreateDto>
    {
        public KeywordCreateDtoValidator()
        {
            RuleFor(x => x.Word)
                .NotEmpty()
                .WithMessage("Word is required")
                .MaximumLength(100)
                .WithMessage("Word cannot exceed 100 characters");
        }
    }
} 