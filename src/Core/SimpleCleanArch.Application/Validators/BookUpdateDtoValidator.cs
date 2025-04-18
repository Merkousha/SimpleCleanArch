using FluentValidation;
using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Validators
{
    public class BookUpdateDtoValidator : AbstractValidator<BookUpdateDto>
    {
        public BookUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(200)
                .WithMessage("Title cannot exceed 200 characters");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(2000)
                .WithMessage("Description cannot exceed 2000 characters");

            RuleFor(x => x.Isbn)
                .NotEmpty()
                .WithMessage("ISBN is required")
                .MaximumLength(20)
                .WithMessage("ISBN cannot exceed 20 characters");

            RuleFor(x => x.PublicationDate)
                .NotEmpty()
                .WithMessage("Publication date is required");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Stock quantity must be greater than or equal to 0");

            RuleFor(x => x.AuthorIds)
                .NotEmpty()
                .WithMessage("At least one author must be specified");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .WithMessage("At least one category must be specified");
        }
    }
} 