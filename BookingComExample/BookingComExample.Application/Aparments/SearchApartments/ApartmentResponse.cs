namespace BookingComExample.Application.Aparments.SearchApartments;

public sealed class ApartmentResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public AddressResponse Address { get; set; }
}