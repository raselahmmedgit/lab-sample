using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace AeonicTech.TestApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllTypes(this IServiceCollection services, Assembly assemblie, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var typesFromAssemblies = assemblie.DefinedTypes;

            foreach (var type in typesFromAssemblies)
            {
                var itypesFromAssemblies = type.Assembly.DefinedTypes.Where(x => x.GetTypeInfo() == type).SelectMany(c=> c.GetInterfaces());
                foreach (var iface in itypesFromAssemblies)
                {
                    if (iface.GetMembers().Any())
                    {
                        services.Add(new ServiceDescriptor(iface, type, lifetime));
                    }
                }
            }
        }

        public static void RegisterCustomRoute(this IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                //options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/AppBase/Views/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/AppBase/Views/{1}/{0}.cshtml");

            });
        }
    }
}
