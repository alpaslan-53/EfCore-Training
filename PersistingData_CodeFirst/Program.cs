// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
Console.WriteLine();
#region Veri Ekleme
DbFirstKitaplık501DbContext context = new();
Book book = new()
{
    KitapAdi = "Muhittin",
    Fiyat = 60
};

context.Add(book);
context.SaveChanges();
//context.SaveChanges();
//await context.SaveChangesAsync();

public class DbFirstKitaplık501DbContext:DbContext
{
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=CodeFirst501KitaplıkDb;Trusted_Connection=True;TrustServerCertificate=Yes"
                  );
    }
}

public class Book
{
    public int Id { get; set; }
    public string KitapAdi { get; set; }
    public double Fiyat { get; set; }
}
#endregion