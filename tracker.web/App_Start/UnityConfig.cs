using System;
using tracker.application.Contracts;
using tracker.application.Services;
using tracker.domain.Repositories;
using tracker.domain.Services;
using tracker.infrastructure.Data;
using tracker.infrastructure.Repositories;
using tracker.infrastructure.Services;
using Unity;
using Unity.Lifetime;

namespace tracker.web
{
    public static class UnityConfig
    {
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<TrackerContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
        }
    }
}