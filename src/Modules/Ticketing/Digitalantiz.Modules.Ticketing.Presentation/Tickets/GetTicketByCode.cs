using Digitalantiz.Common.Domain;
using Digitalantiz.Common.Presentation.ApiResults;
using Digitalantiz.Common.Presentation.Endpoints;
using Digitalantiz.Modules.Ticketing.Application.Tickets.GetTicket;
using Digitalantiz.Modules.Ticketing.Application.Tickets.GetTicketByCode;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Digitalantiz.Modules.Ticketing.Presentation.Tickets;

internal sealed class GetTicketByCode : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("tickets/code/{code}", async (string code, ISender sender) =>
        {
            Result<TicketResponse> result = await sender.Send(new GetTicketByCodeQuery(code));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Tickets);
    }
}
