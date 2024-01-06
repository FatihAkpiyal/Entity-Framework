using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

Console.WriteLine("hello"); 


EBookDbContext context = new EBookDbContext();
Book Book = new()
{
    BookName = "48 Laws Of The Power",
    BookPrice = 10,
    
};

Author Author = new()
{
    AuthorName = "Steve Jobsu",
    AuthorAge = 48,

};

await context.Books.AddAsync(Book);

Author aa = await context.Authors.FirstOrDefaultAsync(a => a.Id == 2);
context.Authors.Remove(aa);
await context.SaveChangesAsync();

class Book
{
    public int Id { get; set; }
    public string? BookName { get; set; }
    public int? BookPrice { get; set; }


    public ICollection<Author>? Authors { get; set;}
}

//class fsjadjlksa
//{

//      public int Id { get; set; }
//}

class Author
{
   
    public int Id { get; set; }

    public string? AuthorName { get; set; }

    public int? AuthorAge { get; set; }
    public ICollection<Book>? Books { get; set; }

}

class EBookDbContext : DbContext
{
    public DbSet<Book>? Books { get; set; }
    public DbSet<Author>? Authors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-4SA5O3O\\SQLEXPRESS;DataBase=EbookData;User Id=sa;Password=31hatay31");
    }
}



