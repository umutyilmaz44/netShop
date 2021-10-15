﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using netShop.Persistence.Content;
using netShop.Application.Interfaces.Context;
using netShop.Application.Interfaces.Repository.Base;
using netShop.Persistence.Repositories.Base;

namespace netShop.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("netShop.Persistence")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>()) ;  
            services.AddScoped<IUnitOfWork>(provider => provider.GetService<UnitOfWork>()) ;   
        }
    }
}