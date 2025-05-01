using Digitalantiz.Modules.Ticketing.Domain.Orders;

namespace Digitalantiz.Modules.Ticketing.Application.Orders.GetOrders;

public sealed record OrderResponse(
    Guid Id,
    Guid CustomerId,
    OrderStatus Status,
    decimal TotalPrice,
    DateTime CreatedAtUtc);
