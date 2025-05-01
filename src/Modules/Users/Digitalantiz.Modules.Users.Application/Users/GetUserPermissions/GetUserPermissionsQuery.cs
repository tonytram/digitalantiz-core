using Digitalantiz.Common.Application.Authorization;
using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Users.Application.Users.GetUserPermissions;

public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;
