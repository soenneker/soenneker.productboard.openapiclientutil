using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.ProductBoard.HttpClients.Registrars;
using Soenneker.ProductBoard.OpenApiClientUtil.Abstract;

namespace Soenneker.ProductBoard.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the Productboard API v2 client provider.
/// </summary>
public static class ProductBoardOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ProductBoardOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddProductBoardOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddProductBoardOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IProductBoardOpenApiClientUtil, ProductBoardOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ProductBoardOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddProductBoardOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddProductBoardOpenApiHttpClientAsSingleton()
                .TryAddScoped<IProductBoardOpenApiClientUtil, ProductBoardOpenApiClientUtil>();

        return services;
    }
}
