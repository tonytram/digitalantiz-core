using System.Data.Common;
using Dapper;
using Digitalantiz.Common.Application.Data;
using Digitalantiz.Common.Application.Messaging;
using Digitalantiz.Common.Domain;

namespace Digitalantiz.Modules.Ticketing.Application.Orders.GetOrders;

internal sealed class GetOrdersQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetOrdersQuery, IReadOnlyCollection<OrderResponse>>
{
    public async Task<Result<IReadOnlyCollection<OrderResponse>>> Handle(
        GetOrdersQuery request,
        CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
             SELECT
                 id AS {nameof(OrderResponse.Id)},
                 customer_id AS {nameof(OrderResponse.CustomerId)},
                 status AS {nameof(OrderResponse.Status)},
                 total_price AS {nameof(OrderResponse.TotalPrice)},
                 created_at_utc AS {nameof(OrderResponse.CreatedAtUtc)}
             FROM ticketing.orders
             WHERE customer_id = @CustomerId
             """;

        List<OrderResponse> orders = (await connection.QueryAsync<OrderResponse>(sql, request)).AsList();

        return orders;
    }
}
