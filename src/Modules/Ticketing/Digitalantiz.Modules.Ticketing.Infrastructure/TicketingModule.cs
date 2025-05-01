using Digitalantiz.Common.Infrastructure.Interceptors;
using Digitalantiz.Common.Presentation.Endpoints;
using Digitalantiz.Modules.Ticketing.Application.Abstractions.Data;
using Digitalantiz.Modules.Ticketing.Application.Abstractions.Payments;
using Digitalantiz.Modules.Ticketing.Application.Carts;
using Digitalantiz.Modules.Ticketing.Domain.Customers;
using Digitalantiz.Modules.Ticketing.Domain.Events;
using Digitalantiz.Modules.Ticketing.Domain.Orders;
using Digitalantiz.Modules.Ticketing.Domain.Payments;
using Digitalantiz.Modules.Ticketing.Domain.Tickets;
using Digitalantiz.Modules.Ticketing.Infrastructure.Customers;
using Digitalantiz.Modules.Ticketing.Infrastructure.Database;
using Digitalantiz.Modules.Ticketing.Infrastructure.Events;
using Digitalantiz.Modules.Ticketing.Infrastructure.Orders;
using Digitalantiz.Modules.Ticketing.Infrastructure.Payments;
using Digitalantiz.Modules.Ticketing.Infrastructure.Tickets;
using Digitalantiz.Modules.Ticketing.Presentation.Customers;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Digitalantiz.Modules.Ticketing.Infrastructure;

public static class TicketingModule
{
    public static IServiceCollection AddTicketingModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        services.AddEndpoints(Presentation.AssemblyReference.Assembly);

        return services;
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumer<UserRegisteredIntegrationEventConsumer>();
    }

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TicketingDbContext>((sp, options) =>
            options
                .UseNpgsql(
                    configuration.GetConnectionString("Database"),
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Ticketing))
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>())
                .UseSnakeCaseNamingConvention());

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TicketingDbContext>());

        services.AddSingleton<CartService>();
        services.AddSingleton<IPaymentService, PaymentService>();
    }
}
