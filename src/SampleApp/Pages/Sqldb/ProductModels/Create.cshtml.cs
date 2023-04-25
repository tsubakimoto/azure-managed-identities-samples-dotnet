namespace SampleApp.Pages.Sqldb.ProductModels;

public class CreateModel : PageModel
{
    private readonly SampleApp.Data.SalesLTContext _context;

    public CreateModel(SampleApp.Data.SalesLTContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public ProductModel ProductModel { get; set; } = default!;
    

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid || _context.ProductModel == null || ProductModel == null)
        {
            return Page();
        }

        _context.ProductModel.Add(ProductModel);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
