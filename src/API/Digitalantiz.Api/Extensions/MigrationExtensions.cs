using Digitalantiz.Modules.Events.Infrastructure.Database;
using Digitalantiz.Modules.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Digitalantiz.Api.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigrations<EventsDbContext>(scope);
        ApplyMigrations<UsersDbContext>(scope);
    }

    private static void ApplyMigrations<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
