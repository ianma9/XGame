using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Repositories.Base;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Services;
using XGame.Infra.Persistence;
using XGame.Infra.Persistence.Repositories;
using XGame.Infra.Persistence.Repositories.Base;
using XGame.Infra.Transactions;

namespace XGame.IoC.Unity
{
    public class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, XGameDataContext>(new HierarchicalLifetimeManager());

            //UnitOfWork

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Domain Service
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IServicePlayer, ServicePlayer>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceGame, ServiceGame>(new HierarchicalLifetimeManager());



            //Repository
            container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IRepositoryPlayer, RepositoryPlayer>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepositoryGame, RepositoryGame>(new HierarchicalLifetimeManager());
        }
    }
}
