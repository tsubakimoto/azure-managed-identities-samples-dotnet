namespace SampleApp.Pages.Storage.Blob;

public class IndexModel : PageModel
{
    private readonly string _storageAccountName;

    public IndexModel(IConfiguration configuration)
    {
        _storageAccountName = configuration["Azure:Storage:AccountName"] ?? string.Empty;
    }

    public List<string> BlobNames { get; private set; } = new();

    public async Task OnGet()
    {
        Uri containerEndpoint = new($"https://{_storageAccountName}.blob.core.windows.net/images");
        DefaultAzureCredential credential = new();

#if DEBUG
        using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
        credential = new(
            new DefaultAzureCredentialOptions
            {
                Diagnostics =
                {
                    LoggedHeaderNames = { "x-ms-request-id" },
                    LoggedQueryParameters = { "api-version" },
                    IsLoggingContentEnabled = true
                },
            }
        );
#endif

        BlobContainerClient containerClient = new(containerEndpoint, credential);

        List<string> names = new();
        await foreach (BlobItem blob in containerClient.GetBlobsAsync())
        {
            names.Add(blob.Name);
        }
        BlobNames = names;
    }
}
