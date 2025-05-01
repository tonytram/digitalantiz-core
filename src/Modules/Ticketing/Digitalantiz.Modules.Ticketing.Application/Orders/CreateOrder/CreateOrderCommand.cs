using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Orders.CreateOrder;

public sealed record CreateOrderCommand(Guid CustomerId) : ICommand;
