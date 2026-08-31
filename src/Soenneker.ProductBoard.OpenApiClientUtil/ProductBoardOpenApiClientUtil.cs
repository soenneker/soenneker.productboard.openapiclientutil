using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.ProductBoard.HttpClients.Abstract;
using Soenneker.ProductBoard.OpenApiClientUtil.Abstract;
using Soenneker.ProductBoard.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ProductBoard.OpenApiClientUtil;

public sealed class ProductBoardOpenApiClientUtil : IProductBoardOpenApiClientUtil
{
    private readonly AsyncSingleton<ProductBoardOpenApiClient> _client;

    public ProductBoardOpenApiClientUtil(IProductBoardOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<ProductBoardOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

            return new ProductBoardOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<ProductBoardOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
