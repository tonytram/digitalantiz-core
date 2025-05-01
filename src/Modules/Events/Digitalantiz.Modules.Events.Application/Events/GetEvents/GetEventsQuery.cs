using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.Events.GetEvents;

public sealed record GetEventsQuery : IQuery<IReadOnlyCollection<EventResponse>>;
