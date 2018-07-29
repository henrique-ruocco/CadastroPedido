using System.Reflection;
using System.Web.Mvc;
using CadastroPedidosCore.Context;
using CadastroPedidosCore.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace CadastroPedidos
{
    public class SimpleInjectorConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterDependencies();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }

    

    public static class DependencyModule
    {
        private static readonly Lifestyle Lifestyle = Lifestyle.Scoped;

        public static void RegisterDependencies(this Container container)
        {
            container.RegisterGlobal();
            container.RegisterServices();
        }

        private static void RegisterGlobal(this Container container)
        {
            container.Register<DBContext>(Lifestyle);
        }

        private static void RegisterServices(this Container container)
        {
            //container.Register<IPedidoService, PedidoService>(Lifestyle);
        }
    }
}