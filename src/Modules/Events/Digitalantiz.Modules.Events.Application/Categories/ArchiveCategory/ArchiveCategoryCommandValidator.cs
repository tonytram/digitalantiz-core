using FluentValidation;

namespace Digitalantiz.Modules.Events.Application.Categories.ArchiveCategory;

internal sealed class ArchiveCategoryCommandValidator : AbstractValidator<ArchiveCategoryCommand>
{
    public ArchiveCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}
