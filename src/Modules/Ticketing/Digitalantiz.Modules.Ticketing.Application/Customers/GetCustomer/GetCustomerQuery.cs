using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Customers.GetCustomer;

public sealed record GetCustomerQuery(Guid CustomerId) : IQuery<CustomerResponse>;
