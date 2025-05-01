using Microsoft.AspNetCore.Authorization;

namespace Digitalantiz.Common.Infrastructure.Authorization;

internal sealed class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}
