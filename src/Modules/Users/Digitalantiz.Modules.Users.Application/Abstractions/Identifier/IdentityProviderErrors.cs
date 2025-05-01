using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Users.Application.Abstractions.Identifier;

public static class IdentityProviderErrors
{
    public static readonly Error EmailIsNotUnique = Error.Conflict(
        "Identity.EmailIsNotUnique",
        "The specified email is not unique");
}
