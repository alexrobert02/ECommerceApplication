﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceApplication.Application
{
    public static class ApplicationServiceRegistrationDI
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR
                (
                    cfg => cfg.RegisterServicesFromAssembly(

                        Assembly.GetExecutingAssembly())
                );
        }
    }
}
