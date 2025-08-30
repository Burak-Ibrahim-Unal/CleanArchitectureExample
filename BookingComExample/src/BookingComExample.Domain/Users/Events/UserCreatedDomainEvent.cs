using BookingComExample.Domain.Abstractions;

namespace BookingComExample.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
