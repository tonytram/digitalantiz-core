using Digitalantiz.Common.Application.Messaging;

namespace Digitalantiz.Modules.Ticketing.Application.Tickets.ArchiveTicketsForEvent;

public sealed record ArchiveTicketsForEventCommand(Guid EventId) : ICommand;
