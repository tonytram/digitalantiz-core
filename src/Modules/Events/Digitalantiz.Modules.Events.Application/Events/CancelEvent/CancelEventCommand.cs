using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Events.CancelEvent;

public sealed record CancelEventCommand(Guid EventId) : ICommand;
