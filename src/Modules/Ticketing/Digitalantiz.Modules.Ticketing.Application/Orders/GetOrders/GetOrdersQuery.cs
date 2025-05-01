using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Orders.GetOrders;

public sealed record GetOrdersQuery(Guid CustomerId) : IQuery<IReadOnlyCollection<OrderResponse>>;
