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
    ValueTask<ProductBoardOpenApiClient> Get(CancellationToken cancellationToken = default);
}
