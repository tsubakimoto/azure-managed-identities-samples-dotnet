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
GROUP=<put-your-resource-group-name>
STORAGE_ACCOUNT_NAME=$(az storage account list --query "[0].name" -g $GROUP --output tsv)

cd src/SampleApp
dotnet user-secrets set Azure:Storage:AccountName $STORAGE_ACCOUNT_NAME
```

### Blob
- [Azure Storage samples using .NET | Microsoft Learn](https://learn.microsoft.com/en-us/azure/storage/common/storage-samples-dotnet#blob-samples)
- [Storage Blob Data Contributor](https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#storage-blob-data-contributor)

### Queue
- [Azure Storage samples using .NET | Microsoft Learn](https://learn.microsoft.com/en-us/azure/storage/common/storage-samples-dotnet#queue-samples)
- [Storage Queue Data Contributor](https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#storage-queue-data-contributor)

## Web Apps
- [Managed identities - Azure App Service | Microsoft Learn](https://learn.microsoft.com/en-us/azure/app-service/overview-managed-identity?tabs=portal%2Chttp)
