using Digitalantiz.Common.Application.Authorization;
using Digitalantiz.Common.Domain;
using Digitalantiz.Modules.Users.Application.Users.GetUserPermissions;
using MediatR;

namespace Digitalantiz.Modules.Users.Infrastructure.Authorization;

internal sealed class PermissionService(ISender sender) : IPermissionService
{
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identifyId)
    {
        return await sender.Send(new GetUserPermissionsQuery(identifyId));
    }
}
