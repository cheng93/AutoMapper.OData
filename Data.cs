namespace OData.AutoMapper;

public static class Data
{
    public static IQueryable<Category> Categories
        => new[]
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "CategoryOne",
                Products = new[]
                {
                    new Product
                    {
                        ProductId = 1,
                        ProductName = "ProductOne",
                    },
                    new Product
                    {
                        ProductId = 2,
                        ProductName = "ProductTwo",
                    },
                    new Product
                    {
                        ProductId = 3,
                        ProductName = "ProductThree",
                    },
                }.AsQueryable(),
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "CategoryTwo",
                Products = new[]
                {
                    new Product
                    {
                        ProductId = 4,
                        ProductName = "ProductFour",
                    },
                    new Product
                    {
                        ProductId = 5,
                        ProductName = "ProductFive",
                    }
                }.AsQueryable(),
            }
        }.AsQueryable();
}

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
}

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public IEnumerable<Product> Products { get; set; }
}