using System.Security.Claims;
using Digitalantiz.Common.Application.Exceptions;

namespace Digitalantiz.Common.Infrastructure.Authentication;

public static class ClaimPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        string? userId = principal?.FindFirst(CustomClaims.Sub)?.Value;

        return Guid.TryParse(userId, out Guid parsedUserId)
            ? parsedUserId
            : throw new DigitalantizException("User identifier is unavailable");
    }

    public static string GetIdentifier(this ClaimsPrincipal principal)
    {
        return principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? throw new DigitalantizException("User identifier is unavailable");
    }

    public static HashSet<string> GetPermissions(this ClaimsPrincipal? principal)
    {
        IEnumerable<Claim> permissionClaims = principal?.FindAll(CustomClaims.Permission) ?? 
                                              throw new DigitalantizException("Permission are unavailable");

        return permissionClaims.Select(claim => claim.Value).ToHashSet();
    }
}
