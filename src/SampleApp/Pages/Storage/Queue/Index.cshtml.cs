namespace SampleApp.Pages.Storage.Queue;

public class IndexModel : PageModel
{
    private readonly string _storageAccountName;

    public IndexModel(IConfiguration configuration)
    {
        _storageAccountName = configuration["Azure:Storage:AccountName"] ?? string.Empty;
    }

    public List<string> QueueValues { get; private set; } = new();

    [BindProperty]
    [Required]
    public string NewMessage { get; set; } = string.Empty;

    public void OnGet()
    {
        QueueClient queue = GetQueueClient();

        List<string> numbers = new();
        foreach (PeekedMessage message in queue.PeekMessages(maxMessages: 10).Value)
        {
            numbers.Add(message.Body.ToString());
        }
        QueueValues = numbers;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        QueueClient queue = GetQueueClient();
        await queue.SendMessageAsync(NewMessage);

        return RedirectToPage("./Index");
    }

    private QueueClient GetQueueClient()
    {
        Uri queueUri = new($"https://{_storageAccountName}.queue.core.windows.net/numbers");
        DefaultAzureCredential credential = new();

#if DEBUG
        AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
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

        return new(queueUri, credential);
    }
}
