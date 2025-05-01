using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Payments.RefundPayment;

public sealed record RefundPaymentCommand(Guid PaymentId, decimal Amount) : ICommand;
