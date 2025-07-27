using System;
using System.Threading;
using System.Threading.Tasks;
using BookingComExample.Application.Abstractions.Clock;
using BookingComExample.Application.Abstractions.Messaging;
using BookingComExample.Domain.Abstractions;
using BookingComExample.Domain.Apartments;
using BookingComExample.Domain.Bookings;
using BookingComExample.Domain.Users;

namespace BookingComExample.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingService;
    private readonly IDatetimeProvider _datetimeProvider;

    public ReserveBookingCommandHandler(IUserRepository userRepository, IApartmentRepository apartmentRepository,
        IBookingRepository bookingRepository, IUnitOfWork unitOfWork, PricingService pricingService,
        IDatetimeProvider datetimeProvider)
    {
        _userRepository = userRepository;
        _apartmentRepository = apartmentRepository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
        _datetimeProvider = datetimeProvider;
    }

    public async Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var apartment = await _apartmentRepository.GetByIdAsync(request.AparmantId, cancellationToken);
        if (apartment is null)
        {
            return Result.Failure<Guid>(ApartmentErrors.NotFound);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        //TODO Buraya bak tekrar
        var booking = await _bookingRepository.IsOverlappingAsync(apartment, duration, cancellationToken);
        if (booking)
        {
            return Result.Failure<Guid>(BookingErrors.Overlap);
        }

        var newBooking = Booking.Reserve(
            apartment,
            user.Id,
            duration,
            _datetimeProvider.UtcNow,
            _pricingService);

        _bookingRepository.Add(newBooking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newBooking.Id;
    }
}