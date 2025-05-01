using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Payments.RefundPaymentsForEvent;

public sealed record RefundPaymentsForEventCommand(Guid EventId) : ICommand;
