﻿using BookingComExample.Domain.Bookings;
using Microsoft.Extensions.DependencyInjection;

namespace BookingComExample.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddTransient<PricingService>();
        
        return services;
    }
}