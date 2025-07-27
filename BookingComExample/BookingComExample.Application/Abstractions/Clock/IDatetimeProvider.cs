using System;

namespace BookingComExample.Application.Abstractions.Clock;

public interface IDatetimeProvider
{
    DateTime UtcNow { get; }
}