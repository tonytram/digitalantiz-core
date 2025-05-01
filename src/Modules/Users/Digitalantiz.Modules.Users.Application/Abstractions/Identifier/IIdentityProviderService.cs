using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Users.Application.Abstractions.Identifier;

public interface IIdentityProviderService
{
    Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
}
