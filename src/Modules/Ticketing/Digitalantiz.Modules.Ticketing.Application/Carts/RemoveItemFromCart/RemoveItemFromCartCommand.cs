using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Carts.RemoveItemFromCart;

public sealed record RemoveItemFromCartCommand(Guid CustomerId, Guid TicketTypeId) : ICommand;
