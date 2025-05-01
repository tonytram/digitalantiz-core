using Digitalantiz.Common.Application.Clock;

namespace Digitalantiz.Common.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
