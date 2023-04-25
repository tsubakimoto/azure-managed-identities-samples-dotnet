namespace SampleApp.Models;

public class ProductModel
{
    [Key]
    public int ProductModelId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? CatalogDescription { get; set; } = null;

    public Guid rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }
}
