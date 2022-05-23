namespace OData.AutoMapper;

using System.ComponentModel.DataAnnotations;
using global::AutoMapper;

public class ProductModel
{
    [Key]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
}

public class CategoryModel
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public IEnumerable<ProductModel> Products { get; set; }
}

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Product, ProductModel>();
        CreateMap<Category, CategoryModel>();
    }
}