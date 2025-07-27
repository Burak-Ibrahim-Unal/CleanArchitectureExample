using System;
using System.Threading;
using System.Threading.Tasks;
using BookingComExample.Application.Abstractions.Messaging;
using BookingComExample.Domain.Abstractions;
using BookingComExample.Domain.Apartments;
using BookingComExample.Domain.Bookings;
using BookingComExample.Domain.Users;

namespace BookingComExample.Application.Bookings.ReserveBooking;

internal sealed class ReserveBookingCommandHandler : ICommandHandler<ReserveBookingCommand,Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PricingService _pricingService;

    public ReserveBookingCommandHandler(IUserRepository userRepository, IApartmentRepository apartmentRepository, IBookingRepository bookingRepository, IUnitOfWork unitOfWork, PricingService pricingService)
    {
        _userRepository = userRepository;
        _apartmentRepository = apartmentRepository;
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _pricingService = pricingService;
    }
    
    public Task<Result<Guid>> Handle(ReserveBookingCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}