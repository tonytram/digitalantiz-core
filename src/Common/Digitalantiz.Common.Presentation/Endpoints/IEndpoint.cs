using Microsoft.AspNetCore.Routing;

namespace Digitalantiz.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
