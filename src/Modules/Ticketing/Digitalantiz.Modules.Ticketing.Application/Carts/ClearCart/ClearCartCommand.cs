using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Carts.ClearCart;

public sealed record ClearCartCommand(Guid CustomerId) : ICommand;
