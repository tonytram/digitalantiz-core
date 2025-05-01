using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Modules.Events.Application.TicketTypes.GetTicketType;

namespace Digitalantiz.Modules.Events.Application.TicketTypes.GetTicketTypes;

public sealed record GetTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeResponse>>;
