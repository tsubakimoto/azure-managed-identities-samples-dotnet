namespace SampleApp.Pages.Sqldb.ProductModels;

public class DeleteModel : PageModel
{
    private readonly SampleApp.Data.SalesLTContext _context;

    public DeleteModel(SampleApp.Data.SalesLTContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null || _context.ProductModel == null)
        {
            return NotFound();
        }
        var productmodel = await _context.ProductModel.FindAsync(id);

        if (productmodel != null)
        {
            ProductModel = productmodel;
            _context.ProductModel.Remove(ProductModel);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
