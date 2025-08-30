using BookingComExample.Domain.Abstractions;

namespace BookingComExample.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;