using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;

Console.WriteLine("hello");


EBookDbContext context = new EBookDbContext();

class Book
{
    public Book() 
    {
        Authors = new HashSet<BookAuthor>();
    }
    public int Id { get; set; }
    public string? BookName { get; set; }

    public ICollection<BookAuthor> Authors { get; set; } 
  
}

class BookAuthor // If we want to use Fluen Api we have to add cross table manually!
{
    public int BookId { get; set; }
    public int AuthorId { get; set; } 

    public Book Book { get; set; }  
    public Author Author { get; set; }
}

class Author
{
    public Author() 
    {
        Books = new HashSet<BookAuthor>();
    }
     public int Id { get; set; }
    public string? AuthorName { get; set; }
    public ICollection<BookAuthor> Books { get; set; }

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



