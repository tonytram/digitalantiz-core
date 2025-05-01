using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
