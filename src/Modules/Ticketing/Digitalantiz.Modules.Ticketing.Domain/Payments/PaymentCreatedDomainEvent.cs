﻿using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Ticketing.Domain.Payments;

public sealed class PaymentCreatedDomainEvent(Guid paymentId) : DomainEvent
{
    public Guid PaymentId { get; init; } = paymentId;
}
