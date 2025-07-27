using BookingComExample.Domain.Abstractions;

namespace BookingComExample.Domain.Apartments;

public class ApartmentErrors
{
    public static Error NotFound = new("Apartment.NotFound", "Apartment with specified identifier is not found");
    
    public static Error Overlap = new("Apartment.Overlap", "Apartment overlaps with other Apartment");
    
    public static Error NotReserved = new("Apartment.NotReserved", "Apartment is not reserved");
    
    public static Error NotConfirmed = new("Apartment.NotConfirmed", "Apartment is not confirmed");
    
    public static Error AlreadyStarted = new("Apartment.AlreadyStarted", "Apartment is already started");
}