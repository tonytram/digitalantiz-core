using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Customers.UpdateCustomer;

public sealed record UpdateCustomerCommand(Guid CustomerId, string FirstName, string LastName) : ICommand;
