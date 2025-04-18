using FluentValidation;
using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Validators
{
    public class BookDtoValidator : AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug is required")
                .MaximumLength(200).WithMessage("Slug cannot exceed 200 characters")
                .Matches("^[a-z0-9]+(?:-[a-z0-9]+)*$").WithMessage("Slug must be in valid format (lowercase letters, numbers, and hyphens)");

            RuleFor(x => x.PageCount)
                .GreaterThan(0).WithMessage("Page count must be greater than 0");

            RuleFor(x => x.ISBN)
                .NotEmpty().WithMessage("ISBN is required")
                .MaximumLength(13).WithMessage("ISBN cannot exceed 13 characters")
                .Matches("^[0-9-]+$").WithMessage("ISBN must contain only numbers and hyphens");

            RuleFor(x => x.PublishedYear)
                .GreaterThan(1800).WithMessage("Published year must be after 1800")
                .LessThanOrEqualTo(System.DateTime.Now.Year).WithMessage("Published year cannot be in the future");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required");
        }
    }
} 