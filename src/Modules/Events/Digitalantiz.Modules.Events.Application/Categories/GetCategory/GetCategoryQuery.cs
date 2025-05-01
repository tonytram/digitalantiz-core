using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Categories.GetCategory;

public sealed record GetCategoryQuery(Guid CategoryId) : IQuery<CategoryResponse>;
