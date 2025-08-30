using BookingComExample.Domain.Apartments;
using BookingComExample.Domain.Shared;

namespace BookingComExample.Domain.Bookings;

public record PricingDetails(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);