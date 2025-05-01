using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Users.Application.Users.UpdateUser;

public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand;
