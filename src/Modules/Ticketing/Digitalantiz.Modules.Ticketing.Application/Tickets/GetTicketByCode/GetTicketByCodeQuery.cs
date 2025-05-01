using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Modules.Ticketing.Application.Tickets.GetTicket;

namespace Digitalantiz.Modules.Ticketing.Application.Tickets.GetTicketByCode;

public sealed record GetTicketByCodeQuery(string Code) : IQuery<TicketResponse>;
