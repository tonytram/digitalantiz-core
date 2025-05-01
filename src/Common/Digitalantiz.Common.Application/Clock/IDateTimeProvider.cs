namespace Digitalantiz.Common.Application.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
