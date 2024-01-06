using Microsoft.EntityFrameworkCore;

Console.WriteLine("hello");


ExampleDbContext context = new();

Product products = new()
{
    Name = "ShinyComb™",
    Quantity = 25,
    Price = 49.90,
};

await context.Products.AddAsync(products);

await context.SaveChangesAsync();




public class ExampleDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-4SA5O3O\\SQLEXPRESS;Database=ECommerce;User Id=sa;Password=31hatay31;");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
        
    public int Quantity { get; set; }    
    public double Price { get; set; }
}

public class Customer
{

    public int Id { get; set; }
    public string Name { get; set; }


}

