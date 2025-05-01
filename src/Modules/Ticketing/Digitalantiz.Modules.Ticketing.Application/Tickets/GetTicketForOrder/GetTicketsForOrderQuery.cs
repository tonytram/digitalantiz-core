using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Modules.Ticketing.Application.Tickets.GetTicket;

namespace Digitalantiz.Modules.Ticketing.Application.Tickets.GetTicketForOrder;

public sealed record GetTicketsForOrderQuery(Guid OrderId) : IQuery<IReadOnlyCollection<TicketResponse>>;
