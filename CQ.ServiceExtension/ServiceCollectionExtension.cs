﻿using Microsoft.Extensions.DependencyInjection;

namespace CQ.ServiceExtension
{
    public static class ServiceCollectionExtension
    {
        public static void AddService<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory, LifeTime lifeTime)
            where TService : class
            where TImplementation : class, TService
        {
            switch (lifeTime)
            {
                case LifeTime.Scoped:
                    {
                        services.AddScoped<TService, TImplementation>(implementationFactory);
                        break;
                    }

                case LifeTime.Transient:
                    {
                        services.AddTransient<TService, TImplementation>(implementationFactory);

                        break;
                    }
                case LifeTime.Singleton:
                    {
                        services.AddSingleton<TService, TImplementation>(implementationFactory);
                        break;
                    }
            }
        }

        public static void AddService<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory, LifeTime lifeTime)
            where TService : class
        {
            switch (lifeTime)
            {
                case LifeTime.Scoped:
                    {
                        services.AddScoped<TService>(implementationFactory);
                        break;
                    }

                case LifeTime.Transient:
                    {
                        services.AddTransient<TService>(implementationFactory);

                        break;
                    }
                case LifeTime.Singleton:
                    {
                        services.AddSingleton<TService>(implementationFactory);
                        break;
                    }
            }
        }

        public static void AddService<TService, TImplementation>(this IServiceCollection services, LifeTime lifeTime)
            where TService : class
            where TImplementation : class, TService
        {
            switch (lifeTime)
            {
                case LifeTime.Scoped:
                    {
                        services.AddScoped<TService, TImplementation>();
                        break;
                    }

                case LifeTime.Transient:
                    {
                        services.AddTransient<TService, TImplementation>();

                        break;
                    }
                case LifeTime.Singleton:
                    {
                        services.AddSingleton<TService, TImplementation>();
                        break;
                    }
            }
        }
    }
}