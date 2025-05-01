using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Users.Application.Users.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
