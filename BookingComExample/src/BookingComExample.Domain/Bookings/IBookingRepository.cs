namespace BookingComExample.Domain.Apartments;

public interface IBookingRepository
{
    Task<Apartment> GetByIdAsync(Guid id,CancellationToken cancellationToken = default);
}