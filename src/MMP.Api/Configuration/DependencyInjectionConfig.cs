using Microsoft.Extensions.DependencyInjection;
using MMP.Domain.Models.Classes.Repository;
using MMP.Infra.Data.Context;
using MMP.Infra.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using MediatR;
using System;
using MMP.Application.Queries;
using MMP.Application.ViewModels;
using System.Collections.Generic;
using System.Reflection;

namespace MMP.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MmpDbContext>();
            services.AddScoped<IClassTypeRepository, ClassTypeRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IVenueRepository, VenueRepository>();
            
            services.AddMediatR(AppDomain.CurrentDomain.Load("mmp.application"));
           
            return services;
        }
        
    }
}