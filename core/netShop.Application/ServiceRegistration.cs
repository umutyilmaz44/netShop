using System;
using System.Collections.Generic;
using System.Text; 
using System.Reflection; 
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace netShop.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assmb = Assembly.GetExecutingAssembly();
            
            services.AddAutoMapper(assmb);
            services.AddMediatR(assmb);
        }
    }
}