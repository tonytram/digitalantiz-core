using Digitalantiz.Common.Infrastructure.Interceptors;
using Digitalantiz.Common.Presentation.Endpoints;
using Digitalantiz.Modules.Events.Application.Abstractions.Data;
using Digitalantiz.Modules.Events.Domain.Categories;
using Digitalantiz.Modules.Events.Domain.Events;
using Digitalantiz.Modules.Events.Domain.TicketTypes;
using Digitalantiz.Modules.Events.Infrastructure.Categories;
using Digitalantiz.Modules.Events.Infrastructure.Database;
using Digitalantiz.Modules.Events.Infrastructure.Events;
using Digitalantiz.Modules.Events.Infrastructure.TicketTypes;
using Digitalantiz.Modules.Events.Presentation.Categories;
using Digitalantiz.Modules.Events.Presentation.Events;
using Digitalantiz.Modules.Events.Presentation.TicketTypes;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digitalantiz.Modules.Events.Infrastructure;

public static class EventsModule
{
    public static IServiceCollection AddEventsModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        services.AddInfrastructure(configuration);

        return services;
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<EventsDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}
