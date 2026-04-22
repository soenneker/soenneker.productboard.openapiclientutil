using Soenneker.ProductBoard.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.ProductBoard.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ProductBoardOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IProductBoardOpenApiClientUtil _openapiclientutil;

    public ProductBoardOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IProductBoardOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
