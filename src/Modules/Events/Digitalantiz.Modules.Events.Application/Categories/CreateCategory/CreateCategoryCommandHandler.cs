using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Common.Domain;
using Digitalantiz.Modules.Events.Application.Abstractions.Data;
using Digitalantiz.Modules.Events.Domain.Categories;

namespace Digitalantiz.Modules.Events.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand>
{
    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name);

        categoryRepository.Insert(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        //return category.Id;

        return Result.Success();
    }
}
