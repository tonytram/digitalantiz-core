using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Ticketing.Application.Carts;

public static class CartErrors
{
    public static readonly Error Empty = Error.Problem("Carts.Empty", "The cart is empty");
}
