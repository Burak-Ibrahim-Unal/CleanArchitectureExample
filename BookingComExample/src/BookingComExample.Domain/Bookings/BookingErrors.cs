using BookingComExample.Domain.Abstractions;

namespace BookingComExample.Domain.Bookings;

public class BookingErrors
{
    public static Error NotFound = new("Booking.NotFound", "Booking with specified identifier is not found");
    
    public static Error Overlap = new("Booking.Overlap", "Booking overlaps with other booking");
    
    public static Error NotReserved = new("Booking.NotReserved", "Booking is not reserved");
    
    public static Error NotConfirmed = new("Booking.NotConfirmed", "Booking is not confirmed");
    
    public static Error AlreadyStarted = new("Booking.AlreadyStarted", "Booking is already started");
}