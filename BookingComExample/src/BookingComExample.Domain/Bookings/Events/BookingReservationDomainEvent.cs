using BookingComExample.Domain.Abstractions;

namespace BookingComExample.Domain.Bookings.Events;

public sealed record BookingReservationDomainEvent(Guid BookingId) : IDomanEvent;
