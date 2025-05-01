using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Orders.GetOrder;

public sealed record GetOrderQuery(Guid OrderId) : IQuery<OrderResponse>;
