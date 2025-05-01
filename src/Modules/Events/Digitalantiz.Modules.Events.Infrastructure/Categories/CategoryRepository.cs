using Digitalantiz.Modules.Events.Domain.Categories;
using Digitalantiz.Modules.Events.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Digitalantiz.Modules.Events.Infrastructure.Categories;

public sealed class CategoryRepository(EventsDbContext dbContext) : ICategoryRepository
{
    public async Task<Category> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Categories.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Insert(Category category)
    {
        dbContext.Categories.Add(category);
    }
}
