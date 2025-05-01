using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Modules.Events.Application.Categories.GetCategory;

namespace Digitalantiz.Modules.Events.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<CategoryResponse>>;
