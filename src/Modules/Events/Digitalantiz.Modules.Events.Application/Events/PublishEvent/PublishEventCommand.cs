using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Events.PublishEvent;

public sealed record PublishEventCommand(Guid EventId) : ICommand;
