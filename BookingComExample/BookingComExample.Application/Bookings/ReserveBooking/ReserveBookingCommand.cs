using System;
using BookingComExample.Application.Abstractions.Messaging;

namespace BookingComExample.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand(
    Guid AparmantId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>;