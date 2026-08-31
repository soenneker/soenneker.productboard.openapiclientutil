using Soenneker.ProductBoard.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.ProductBoard.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached, authenticated client for Productboard API v2.
/// </summary>
public interface IProductBoardOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the generated client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The cached Productboard client.</returns>
    ValueTask<ProductBoardOpenApiClient> Get(CancellationToken cancellationToken = default);
}
