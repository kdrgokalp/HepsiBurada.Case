using Business.Classes;
using Business.Interface;

using Castle.Core.Configuration;
using Castle.DynamicProxy;

using Common.Validation;

using Data.Interface;

using FluentValidation.AspNetCore;

using Infrastructure.Interceptors;
using Infrastructure.Reporsitors;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Serilog;
//using Microsoft.Extensions.Logging;

using Serilog.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public static class ServicesExtensions
    {
        public static void AddProxiedScoped<TInterface, TImplementation>(this IServiceCollection services)
            where TInterface : class
            where TImplementation : class, TInterface
        {
            services.AddScoped<TImplementation>();
            services.AddScoped(typeof(TInterface), serviceProvider =>
            {
                var proxyGenerator = serviceProvider.GetRequiredService<ProxyGenerator>();
                var actual = serviceProvider.GetRequiredService<TImplementation>();
                var interceptors = serviceProvider.GetServices<IInterceptor>().ToArray();
                return proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TInterface), actual, interceptors);
            });
        }


        public static IServiceCollection DependencyOperation(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(fv => 
                                fv.RegisterValidatorsFromAssemblyContaining<CreateCampaignRequestValidator>()
                                  .RegisterValidatorsFromAssemblyContaining<CreateOrderRequestValidator>()
                                  .RegisterValidatorsFromAssemblyContaining<CreateProductRequestValidator>()
                                  .RegisterValidatorsFromAssemblyContaining<GetCampaignByNameRequestValidator>()
                                  .RegisterValidatorsFromAssemblyContaining<GetIncreaseTimeRequestValidator>());

            services.AddSingleton(new  ProxyGenerator());
            services.AddScoped<IInterceptor, LoggingInterceptor>();
            services.AddScoped<IInterceptor, UnitOfWorkInterceptor>();

            services.AddScoped<DbContext, CampaignContext>();
            services.AddProxiedScoped<IProductBusiness, ProductBusiness>();
            services.AddProxiedScoped<ICampaignBusiness, CampaignBusiness>();
            services.AddProxiedScoped<IOrderBusiness, OrderBusiness>();
            services.AddProxiedScoped<ISystemClockBusiness, SystemClockBusiness>();

            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductStockRepository, ProductStockRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        
    }
}
