// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");
public class RelationShipsEfCoreDbContext:DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet <Author>Authors { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
 

    optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database= ManyToManyRelationShipEfCoreDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<YazarKitap>().HasKey(x => new { x.AuthorId, x.BookId });
        modelBuilder.Entity<YazarKitap>().HasOne(x => x.Book).WithMany(u => u.Authors).HasForeignKey(x => x.BookId);
        modelBuilder.Entity<YazarKitap>().HasOne(x => x.Author).WithMany(u => u.Books).HasForeignKey(x => x.AuthorId);
    }
}

//iki entity arasında ilişki naigaiton proplar ile çoğul olarak kurulur.(icollection,list,,,)
//Default convention üzerinde cross table ımız manuel şkeilde olştmrak zorunda değiliz
// ÇÜNKÜ Ef core ortamda çoka çok bir ilişki tespt ettiğinde  cross tabelımız kendisi olştryor olacaktır.
//ekstra içerisindeki PK ları da kendisi tanımlayacaktır.

#region DefaultConvention
//public class Book
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Author> Authors { get; set;} //navigation property
//}

//public class Author
//{
//    public  int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<Book> Books { get; set; }
//}
#endregion


#region Data Annotation




//public class Book
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<YazarKitap> Authors { get; set; } //navigation property
//}

////cross table
//public class YazarKitap
//{
//    [ForeignKey(nameof(Book))]
//    public int BId { get; set; }
//    [ForeignKey(nameof(Author)) ]
//    public  int AId { get; set; }
//    public Book Book { get; set; }
//    public Author Author { get; set; }
//}

//public class Author
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public ICollection<YazarKitap> Books { get; set; }
//}

#endregion

#region FluentAPI
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<YazarKitap> Authors { get; set; } //navigation property
}

//cross table
public class YazarKitap
{
   
    public int BookId { get; set; }
    
    public int AuthorId { get; set; }
    public Book Book { get; set; }
    public Author Author { get; set; }
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<YazarKitap> Books { get; set; }
}

#endregion