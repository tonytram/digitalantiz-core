using Digitalantiz.Modules.Ticketing.Domain.Orders;
using Digitalantiz.Modules.Ticketing.Domain.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitalantiz.Modules.Ticketing.Infrastructure.Payments;

internal sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne<Order>().WithMany().HasForeignKey(p => p.OrderId);

        builder.HasIndex(p => p.TransactionId).IsUnique();
    }
}
