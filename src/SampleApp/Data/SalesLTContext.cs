namespace SampleApp.Data;

public class SalesLTContext : DbContext
{
    public SalesLTContext (DbContextOptions<SalesLTContext> options)
        : base(options)
    {
    }

    public DbSet<ProductModel> ProductModel { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("SalesLT");
    }
}
