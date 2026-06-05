using Soenneker.ProductBoard.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.ProductBoard.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IProductBoardOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<ProductBoardOpenApiClient> Get(CancellationToken cancellationToken = default);
}
