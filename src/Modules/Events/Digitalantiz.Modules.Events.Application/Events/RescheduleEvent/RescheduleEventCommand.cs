using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Events.RescheduleEvent;

public sealed record RescheduleEventCommand(Guid EventId, DateTime StartsAtUtc, DateTime? EndsAtUtc) : ICommand;
