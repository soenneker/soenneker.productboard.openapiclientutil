using Soenneker.ProductBoard.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.ProductBoard.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class ProductBoardOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IProductBoardOpenApiClientUtil _openapiclientutil;

    public ProductBoardOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IProductBoardOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
