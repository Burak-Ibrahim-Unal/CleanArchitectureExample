using BookingComExample.Domain.Abstractions;
using MediatR;

namespace BookingComExample.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
}