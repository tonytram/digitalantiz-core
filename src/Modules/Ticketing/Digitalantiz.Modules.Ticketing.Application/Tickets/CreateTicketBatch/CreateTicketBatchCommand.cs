using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Tickets.CreateTicketBatch;

public sealed record CreateTicketBatchCommand(Guid OrderId) : ICommand;
