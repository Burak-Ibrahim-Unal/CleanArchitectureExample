using BookingComExample.Application.Abstractions.Email;
using BookingComExample.Domain.Apartments;
using BookingComExample.Domain.Bookings.Events;
using BookingComExample.Domain.Users;
using MediatR;

namespace BookingComExample.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    public readonly IBookingRepository _bookingRepository;
    public readonly IUserRepository _userRepository;
    public readonly IEmailService _emailService;

    public BookingReservedDomainEventHandler(
        IBookingRepository bookingRepository,
        IUserRepository userRepository,
        IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);
        if (booking is null)
        {
            return; 
        }
        
        var user= await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);
        if (user is null)
        {
            return;
        }
        
        await _emailService.SendEmailAsync(user.Email, "Booking Reserved", "Please confirm your booking in 10 minutes");
    }
}