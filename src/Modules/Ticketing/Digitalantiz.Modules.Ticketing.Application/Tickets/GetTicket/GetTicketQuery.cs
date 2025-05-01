using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Tickets.GetTicket;

public sealed record GetTicketQuery(Guid TicketId) : IQuery<TicketResponse>;
