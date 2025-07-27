using BookingComExample.Domain.Abstractions;
using MediatR;

namespace BookingComExample.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
    
}