using BookingComExample.Domain.Abstractions;
using MediatR;

namespace BookingComExample.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, BaseCommand
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, BaseCommand
{
}

public interface BaseCommand
{
}