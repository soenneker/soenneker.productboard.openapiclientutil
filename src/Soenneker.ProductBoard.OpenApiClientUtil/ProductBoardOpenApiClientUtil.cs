using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.ProductBoard.HttpClients.Abstract;
using Soenneker.ProductBoard.OpenApiClientUtil.Abstract;
using Soenneker.ProductBoard.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.ProductBoard.OpenApiClientUtil;

///<inheritdoc cref="IProductBoardOpenApiClientUtil"/>
public sealed class ProductBoardOpenApiClientUtil : IProductBoardOpenApiClientUtil
{
    private readonly AsyncSingleton<ProductBoardOpenApiClient> _client;

    public ProductBoardOpenApiClientUtil(IProductBoardOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<ProductBoardOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("ProductBoard:ApiKey");
            string authHeaderValueTemplate = configuration["ProductBoard:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
