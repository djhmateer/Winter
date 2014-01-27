using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Winter.Web
{
    public static class UnityConfig
    {
        public static UnityContainer container { get; set; }

        public static void RegisterComponents()
        {
            container = new UnityContainer();

            // it is NOT necessary to register your controllers
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface, // Convention of an I in front of interface name
                WithName.Default
                );  // Default not a singleton in Unity

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}