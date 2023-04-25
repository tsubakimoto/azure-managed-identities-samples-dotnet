namespace SampleApp.Pages.Sqldb.ProductModels;

public class IndexModel : PageModel
{
    private readonly SampleApp.Data.SalesLTContext _context;

    public IndexModel(SampleApp.Data.SalesLTContext context)
    {
        _context = context;
    }

    public IList<ProductModel> ProductModel { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.ProductModel != null)
        {
            ProductModel = await _context.ProductModel.ToListAsync();
        }
    }
}
