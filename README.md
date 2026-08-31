[![](https://img.shields.io/nuget/v/soenneker.productboard.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.productboard.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.productboard.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.productboard.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.productboard.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.productboard.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.productboard.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.productboard.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.ProductBoard.OpenApiClientUtil

Provides a configured Productboard API v2 client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.ProductBoard.OpenApiClientUtil
```

## Configuration

```json
{
  "ProductBoard": {
    "ApiKey": "your-api-or-oauth-token"
  }
}
```

## Usage

```csharp
using Soenneker.ProductBoard.OpenApiClientUtil.Abstract;
using Soenneker.ProductBoard.OpenApiClientUtil.Registrars;

services.AddProductBoardOpenApiClientUtilAsSingleton();

IProductBoardOpenApiClientUtil productboard = serviceProvider
    .GetRequiredService<IProductBoardOpenApiClientUtil>();

var client = await productboard.Get(cancellationToken);
var notes = await client.Notes.GetAsync(
    cancellationToken: cancellationToken);
```

Use `AddProductBoardOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The authenticated HTTP provider remains shared and is disposed by the service container at shutdown.
