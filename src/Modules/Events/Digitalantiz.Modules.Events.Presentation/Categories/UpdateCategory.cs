using Digitalantiz.Common.Domain;
using Digitalantiz.Common.Presentation.ApiResults;
using Digitalantiz.Common.Presentation.Endpoints;
using Digitalantiz.Modules.Events.Application.Categories.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Digitalantiz.Modules.Events.Presentation.Categories;

internal sealed class UpdateCategory : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}", async (Guid id, Request request, ISender sender) =>
        {
            Result result = await sender.Send(new UpdateCategoryCommand(id, request.Name));

            return result.Match(() => Results.Ok(), ApiResults.Problem);
        })
        .WithTags(Tags.Categories);
    }

    internal sealed class Request
    {
        public string Name { get; init; }
    }
}
