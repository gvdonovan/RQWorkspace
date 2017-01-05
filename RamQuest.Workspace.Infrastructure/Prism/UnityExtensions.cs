using System;
using Microsoft.Practices.Unity;

namespace RamQuest.Workspace.Infrastructure.Prism
{
    public static class UnityContainerExtensions
    {
        public static void RegisterTypeForNavigation<T>(this IUnityContainer container)
        {
            container.RegisterType(typeof(Object), typeof(T), typeof(T).FullName);
        }

        public static void RegisterTypeForNavigation(this IUnityContainer container, Type type)
        {
            container.RegisterType(typeof(Object), type, type.FullName);
        }
    }
}
