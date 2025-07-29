using BookingComExample.Application.Abstractions.Messaging;

namespace BookingComExample.Application.Aparments.SearchApartments;

public sealed record SearchApartmentsQuery(
    DateOnly StartDate, 
    DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;
