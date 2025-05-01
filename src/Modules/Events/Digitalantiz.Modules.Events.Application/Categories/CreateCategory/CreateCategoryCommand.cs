using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(string Name) : ICommand;
