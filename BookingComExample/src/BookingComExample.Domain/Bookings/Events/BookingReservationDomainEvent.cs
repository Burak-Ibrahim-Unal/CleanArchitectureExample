using BookingComExample.Domain.Abstractions;

namespace BookingComExample.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomanEvent;
