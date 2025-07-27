using BookingComExample.Domain.Abstractions;

namespace BookingComExample.Domain.Bookings;

public class UserErrors
{
    public static Error NotFound = new("User.NotFound", "User with specified identifier is not found");
    
    public static Error Overlap = new("User.Overlap", "User overlaps with other User");
    
    public static Error NotReserved = new("User.NotReserved", "User is not reserved");
    
    public static Error NotConfirmed = new("User.NotConfirmed", "User is not confirmed");
    
    public static Error AlreadyStarted = new("User.AlreadyStarted", "User is already started");
}