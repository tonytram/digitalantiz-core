using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Events.Application.TicketTypes.GetTicketType;

public sealed record GetTicketTypeQuery(Guid TicketTypeId) : IQuery<TicketTypeResponse>;
