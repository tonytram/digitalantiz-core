using FluentValidation;

namespace Digitalantiz.Modules.Ticketing.Application.Payments.RefundPayment;

internal sealed class RefundPaymentCommandValidator : AbstractValidator<RefundPaymentCommand>
{
    public RefundPaymentCommandValidator()
    {
        RuleFor(c => c.PaymentId).NotEmpty();
    }
}
