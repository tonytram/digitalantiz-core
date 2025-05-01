using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Common.Domain;
using Digitalantiz.Modules.Ticketing.Application.Abstractions.Data;
using Digitalantiz.Modules.Ticketing.Domain.Events;
using Digitalantiz.Modules.Ticketing.Domain.Orders;
using Digitalantiz.Modules.Ticketing.Domain.Tickets;

namespace Digitalantiz.Modules.Ticketing.Application.Tickets.CreateTicketBatch;

internal sealed class CreateTicketBatchCommandHandler(
    IOrderRepository orderRepository,
    ITicketTypeRepository ticketTypeRepository,
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateTicketBatchCommand>
{
    public async Task<Result> Handle(CreateTicketBatchCommand request, CancellationToken cancellationToken)
    {
        Order? order = await orderRepository.GetAsync(request.OrderId, cancellationToken);

        if (order is null)
        {
            return Result.Failure(OrderErrors.NotFound(request.OrderId));
        }

        Result result = order.IssueTickets();

        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }

        List<Ticket> tickets = [];
        foreach (OrderItem orderItem in order.OrderItems)
        {
            TicketType? ticketType = await ticketTypeRepository.GetAsync(orderItem.TicketTypeId, cancellationToken);

            if (ticketType is null)
            {
                return Result.Failure(TicketTypeErrors.NotFound(orderItem.TicketTypeId));
            }

            for (int i = 0; i < orderItem.Quantity; i++)
            {
                var ticket = Ticket.Create(order, ticketType);

                tickets.Add(ticket);
            }
        }

        ticketRepository.InsertRange(tickets);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
