using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(Guid EventId) : IQuery<EventResponse>;
