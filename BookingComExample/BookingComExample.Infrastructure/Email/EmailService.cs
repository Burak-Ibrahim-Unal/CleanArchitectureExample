using BookingComExample.Application.Abstractions.Email;

namespace BookingComExample.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendEmailAsync(Domain.Users.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}