using BookingComExample.Domain.Bookings;

namespace BookingComExample.Domain.Apartments;

public interface IBookingRepository
{
    Task<Booking> GetByIdAsync(Guid id,CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
    Apartment apartment,
    DateRange duration,
    CancellationToken cancellationToken = default);

    void Add(Booking booking);
}