namespace SampleApp.Pages.Sqldb.ProductModels;

public class EditModel : PageModel
{
    private readonly SampleApp.Data.SalesLTContext _context;

    public EditModel(SampleApp.Data.SalesLTContext context)
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

        var productmodel =  await _context.ProductModel.FirstOrDefaultAsync(m => m.ProductModelId == id);
        if (productmodel == null)
        {
            return NotFound();
        }
        ProductModel = productmodel;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(ProductModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductModelExists(ProductModel.ProductModelId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ProductModelExists(int id)
    {
      return (_context.ProductModel?.Any(e => e.ProductModelId == id)).GetValueOrDefault();
    }
}
