using CadastroPedidos.Context;
using CadastroPedidos.Controllers;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CadastroPedidos.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            DependencyModule.RegisterDependencies(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }

    public interface IPedidoService
    {
        bool ExcluirItem(int id, int idItem);
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
            container.Register<IPedidoService, PedidoService>(Lifestyle);
        }
    }
}