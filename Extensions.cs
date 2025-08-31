using System.Reflection;
using BlazorHtmxDemo.Features;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BlazorHtmxDemo;

public static class Extensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        ServiceDescriptor[] serviceDescriptors = assembly.DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } && type.IsAssignableTo(typeof(IHtmxEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IHtmxEndpoint), type))
            .ToArray();

        services.TryAddEnumerable(serviceDescriptors);

        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        IEnumerable<IHtmxEndpoint> endpoints = app.Services.GetRequiredService<IEnumerable<IHtmxEndpoint>>();
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;
        foreach (IHtmxEndpoint endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }

}