// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


public class DenemeDbContext :DbContext
{
   public DbSet<Urun> Urunler { get; set; }
   public DbSet<Musteri> Musteriler { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { //Provider:usesqlserver,connection string="bu alan sanıyorum :D"
       optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=CodeFirst;Trusted_Connection=True;TrustServerCertificate=Yes"
           );
    }
}
public class Urun
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

public class Musteri
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
} 
