using BookingComExample.Domain.Apartments;

namespace BookingComExample.Domain.Bookings;

public record PricingDetails(Money PriceForPeriod, Money CleaningFee, Money AmenitiesUpCharge, Money TotalPrice);