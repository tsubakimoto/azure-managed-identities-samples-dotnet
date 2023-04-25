namespace SampleApp.Pages.Sqldb.ProductModels;

public class DetailsModel : PageModel
{
    private readonly SampleApp.Data.SalesLTContext _context;

    public DetailsModel(SampleApp.Data.SalesLTContext context)
    {
        _context = context;
    }

  public ProductModel ProductModel { get; set; } = default!; 

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.ProductModel == null)
        {
            return NotFound();
        }

        var productmodel = await _context.ProductModel.FirstOrDefaultAsync(m => m.ProductModelId == id);
        if (productmodel == null)
        {
            return NotFound();
        }
        else 
        {
            ProductModel = productmodel;
        }
        return Page();
    }
}
