//using ClimaTempoSimples.Application.Common.Validation;
using ClimaTempoSimples.Application.Common.Validation;
using ClimaTempoSimples.Application.Queries.Interfaces;
using ClimaTempoSimples.Application.Queries.ListTodaysTopColdestCities;
using ClimaTempoSimples.Application.Queries.ListTodaysTopHottestCities;
using ClimaTempoSimples.Application.Queries.SearchWeatherForecastForNextDaysByCity;
using ClimaTempoSimples.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using MediatR.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ClimaTempoSimples
{
    public static class DependencyContainerConfig
    {
        public static void Configure()
        {
            var container = BuildContainer();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static Container BuildContainer()
        {
            var assemblies = GetAssemblies().ToArray();
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            container.Register<ClimaTempoEntities>(Lifestyle.Scoped);
            container.Register<IWeatherForecastRepository, WheaterForecastRepository>(Lifestyle.Scoped);
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);

            //Handlers
            //RegisterHandlers(container, typeof(INotificationHandler<>), assemblies);
            //RegisterHandlers(container, typeof(IRequestExceptionAction<,>), assemblies);
            //RegisterHandlers(container, typeof(IRequestExceptionHandler<,,>), assemblies);

            container.Collection.Register(typeof(IValidator<>),
                                          AssemblyScanner.FindValidatorsInAssemblies(assemblies)
                                          .Select(result => result.ValidatorType));

            //Pipeline
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                //typeof(RequestExceptionProcessorBehavior<,>),
                //typeof(RequestExceptionActionProcessorBehavior<,>),
                //typeof(RequestPreProcessorBehavior<,>),
                typeof(ValidationBehavior<,>),
                //typeof(RequestPostProcessorBehavior<,>)                
            });

            //container.Collection.Register(typeof(IRequestPreProcessor<>), new[] { typeof(GenericRequestPreProcessor<>) });
            //container.Collection.Register(typeof(IRequestPostProcessor<,>), new[] { typeof(GenericRequestPostProcessor<,>), typeof(ConstrainedRequestPostProcessor<,>) });
            //container.Register(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            container.Verify();
            
            return container;
        }

        private static void RegisterHandlers(Container container, Type collectionType, Assembly[] assemblies)
        {
            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var handlerTypes = container.GetTypesToRegister(collectionType, assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });

            container.Collection.Register(collectionType, handlerTypes);
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(ValidationBehavior<,>).GetTypeInfo().Assembly;
        }
    }
}