# azure-managed-identities-samples-dotnet

- [Azure/azure-sdk-for-net](https://github.com/Azure/azure-sdk-for-net)
- [NuGet Gallery | Azure.Identity](https://www.nuget.org/packages/Azure.Identity)

## Setup

[How to install the Azure CLI | Microsoft Learn](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)

```sh
az login
az account set -s <put-your-azure-subscription-id>
```

## Storage

```sh
cd src/SampleApp
dotnet user-secrets set Azure:Storage:AccountName <put-your-storage-name>
```

### Blob
- [Azure Storage samples using .NET | Microsoft Learn](https://learn.microsoft.com/en-us/azure/storage/common/storage-samples-dotnet#blob-samples)

### Queue
- [Azure Storage samples using .NET | Microsoft Learn](https://learn.microsoft.com/en-us/azure/storage/common/storage-samples-dotnet#queue-samples)

## Web Apps
- [Managed identities - Azure App Service | Microsoft Learn](https://learn.microsoft.com/en-us/azure/app-service/overview-managed-identity?tabs=portal%2Chttp)
