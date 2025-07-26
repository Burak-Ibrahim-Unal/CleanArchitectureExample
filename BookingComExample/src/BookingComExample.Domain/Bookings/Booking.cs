using BookingComExample.Domain.Abstractions;
using BookingComExample.Domain.Apartments;
using BookingComExample.Domain.Bookings.Events;

namespace BookingComExample.Domain.Bookings;

public sealed class Booking : Entity
{
    private Booking(
        Guid id,
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money totalPrice,
        BookingStatus status,
        DateTime createdOnUtc) : base(id)
    {
        
    }

    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }

    public static Booking Reserve(Guid apartmentId,
        Guid userId,
        DateRange duration,
        DateTime createdOnUtc,
        PricingDetails pricingDetails)
    {
        var booking = new Booking(Guid.NewGuid(),
            apartmentId,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            createdOnUtc);;
        
        booking.RaiseDomainEvent(new BookingReservationDomainEvent(booking.Id));;
        
        return booking;
    }
}