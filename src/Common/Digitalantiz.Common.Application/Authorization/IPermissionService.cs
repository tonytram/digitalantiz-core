using Digitalantiz.Common.Domain;

namespace Digitalantiz.Common.Application.Authorization;

public interface IPermissionService
{
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identifyId);
}
