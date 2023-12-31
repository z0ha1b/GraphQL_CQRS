﻿using System.Reflection;
using BuildingBlocks.ExceptionHandler.Behaviours;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Scheduling.Application.Features.Appointment.Queries;

namespace Scheduling.Application.Extensions;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        
        return services;
    }
}