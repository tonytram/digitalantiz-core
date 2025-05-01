using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Categories.ArchiveCategory;

public sealed record ArchiveCategoryCommand(Guid CategoryId) : ICommand;
