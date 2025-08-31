using BookingComExample.Application.Abstractions.Messaging;

namespace BookingComExample.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;