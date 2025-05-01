
using Digitalantiz.Common.Application.Messaging;
namespace Digitalantiz.Modules.Events.Application.Events;

public sealed record CreateEventCommand(
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc) : ICommand<Guid>;
