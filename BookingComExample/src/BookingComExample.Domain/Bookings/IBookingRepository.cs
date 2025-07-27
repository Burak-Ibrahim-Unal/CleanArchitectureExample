using BookingComExample.Domain.Bookings;

namespace BookingComExample.Domain.Apartments;

public interface IBookingRepository
{
    Task<Booking> GetByIdAsync(Guid id,CancellationToken cancellationToken = default);
}