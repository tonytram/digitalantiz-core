using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Carts.GetCart;

public sealed record GetCartQuery(Guid CustomerId) : IQuery<Cart>;
