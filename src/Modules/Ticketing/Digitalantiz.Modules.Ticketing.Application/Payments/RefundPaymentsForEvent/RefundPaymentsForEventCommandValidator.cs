﻿using FluentValidation;

namespace Digitalantiz.Modules.Ticketing.Application.Payments.RefundPaymentsForEvent;

internal sealed class RefundPaymentsForEventCommandValidator : AbstractValidator<RefundPaymentsForEventCommand>
{
    public RefundPaymentsForEventCommandValidator()
    {
        RuleFor(c => c.EventId).NotEmpty();
    }
}
