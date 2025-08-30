using BookingComExample.Application.Abstractions.Clock;

namespace BookingComExample.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDatetimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}