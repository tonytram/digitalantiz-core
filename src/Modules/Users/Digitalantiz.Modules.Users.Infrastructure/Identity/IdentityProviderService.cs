using System.Net;
using Digitalantiz.Common.Domain;
using Digitalantiz.Modules.Users.Application.Abstractions.Identifier;
using Microsoft.Extensions.Logging;

namespace Digitalantiz.Modules.Users.Infrastructure.Identity;

internal sealed class IdentityProviderService(KeyCloakClient keyCloakClient, ILogger<IdentityProviderService> logger) 
    : IIdentityProviderService
{
    private const string PasswordCredentialType = "Password";

    public async Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        var userRepresentation = new UserRepresentation(
            user.Email,
            user.Email,
            user.FirstName,
            user.LastName,
            true,
            true,
            [
                new CredentialRepresentation(PasswordCredentialType, user.Password, false)]);

        try
        {
            string identityId = await keyCloakClient.RegisterUserAsync(userRepresentation, cancellationToken);

            return identityId;
        }
        catch (HttpRequestException exception) when (exception.StatusCode == HttpStatusCode.Conflict)
        {
            logger.LogError(exception, "User registration failed");

            return Result.Failure<string>(IdentityProviderErrors.EmailIsNotUnique);
        }
    }
}
