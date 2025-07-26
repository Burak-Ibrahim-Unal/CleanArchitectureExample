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
        DateTime confirmedOnUtc) : base(id)
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
    public DateTime ConfirmedOnUtc { get; private set; }

    public static Booking Reserve(
        Apartment apartment,
        Guid userId,
        DateRange duration,
        DateTime createdOnUtc,
        PricingService pricingService)
    {
        var pricingDetails = pricingService.CalculatePrice(apartment,duration);

        var booking = new Booking(Guid.NewGuid(),
            apartment.Id,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.CleaningFee,
            pricingDetails.TotalPrice,
            BookingStatus.Reserved,
            createdOnUtc);
        ;

        booking.RaiseDomainEvent(new BookingReservationDomainEvent(booking.Id));
        ;
        apartment.LastBookedOnUtc = createdOnUtc;

        return booking;
    }

    public Result Confirm(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotPending);
        }

        Status = BookingStatus.Confirmed;
        ConfirmedOnUtc = utcNow;

        RaiseDomainEvent(new BookingReservationDomainEvent(Id));

        return Result.Success();
    }

    public Result Reject(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotPending);
        }

        Status = BookingStatus.Rejected;
        ConfirmedOnUtc = utcNow;
        
        RaiseDomainEvent(new BookingReservationDomainEvent(Id));

        return Result.Success();
    }
    
    public Result Complete(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }

        Status = BookingStatus.Completed;
        ConfirmedOnUtc = utcNow;
        
        RaiseDomainEvent(new BookingReservationDomainEvent(Id));

        return Result.Success();
    }
    
    public Result Cancel(DateTime utcNow)
    {
        if (Status != BookingStatus.Reserved)
        {
            return Result.Failure(BookingErrors.NotConfirmed);
        }

        var currentDate = DateOnly.FromDateTime(utcNow);

        if (currentDate > Duration.Start)
        {
            return Result.Failure(BookingErrors.AlreadyStarted);
        }

        Status = BookingStatus.Cancelled;
        ConfirmedOnUtc = utcNow;
        
        RaiseDomainEvent(new BookingReservationDomainEvent(Id));

        return Result.Success();
    }
}