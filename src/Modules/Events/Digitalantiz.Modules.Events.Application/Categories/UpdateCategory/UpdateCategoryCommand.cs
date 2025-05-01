using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid CategoryId, string Name) : ICommand;
