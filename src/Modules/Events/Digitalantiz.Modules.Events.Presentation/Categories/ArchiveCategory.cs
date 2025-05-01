using Digitalantiz.Common.Domain;
using Digitalantiz.Common.Presentation.ApiResults;
using Digitalantiz.Common.Presentation.Endpoints;
using Digitalantiz.Modules.Events.Application.Categories.ArchiveCategory;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Digitalantiz.Modules.Events.Presentation.Categories;

internal sealed class ArchiveCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}/archive", async (Guid id, ISender sender) =>
        {
            Result result = await sender.Send(new ArchiveCategoryCommand(id));

            return result.Match(() => Results.Ok(), ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }
}
