﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Track.Order.Application.Interfaces;
using Track.Order.Infrastructure.Repositories;

namespace Track.Order.Infrastructure;

public static class InfrastructureBootstrapper
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        var connectionString = configuration.GetConnectionString("SqlServerConnection");

        services.AddDbContext<TrackOrderDbContext>(options
            => options
            .UseSqlServer(connectionString));

        // Repositories
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
