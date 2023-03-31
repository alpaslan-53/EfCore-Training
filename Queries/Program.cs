// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

Console.WriteLine("Hello, World!");
Console.WriteLine();



Ecommerc501Dbcontext context = new();

//for (int i = 0; i < 500; i++)
//{
//    Product p = new Product();
//    p.Name = $"ürün {i + 1}";
//    p.Price = i * 10;
//    context.Products.Add(p);
//}
//context.SaveChanges();


//En Temel şekilde sorgu kullanımı


// Gecikmeli Execution (Deffered Execution) --> foreach
//var urunId = 200;
//var products = from x in context.Products where x.Id > urunId && x.Price > 400 select x;
//foreach (var item in products)
//{
//    Console.WriteLine(item.Name + " / " + item.Id + " / " + item.Price);
//}

//urunId = 300;






// Method Syntax
//var products = context.Products.ToList();
//foreach (var item in products)
//{
//    Console.WriteLine($"Ürün adı: {item.Name} / Ürün Fiyatı:{item.Price}");
//}





//Quarry Syntax

//var urunler = await (from x in context.Products select x).ToListAsync();

//foreach (var item in urunler)
//{
//   Console.WriteLine($"Ürün adı: {item.Name} / Ürün Fiyatı:{item.Price}");
//}

//WHERE--Olşturulan sorguya şart ekleme.

var products = context.Products.Where(u => u.Id > 350).ToList();
Console.WriteLine( "***********" );
var products2=await context.Products.Where(u=>u.Name.EndsWith("2")).ToListAsync();
foreach(var item in products2)
{
    Console.WriteLine(item.Name);
}

//Querry Syntax
var urunler=from x in context.Products
            where x.Id>250 && x.Name.EndsWith("2")
            select x;

foreach(var item in urunler)
{
    Console.WriteLine(item.Name);
}










public class Ecommerc501Dbcontext: DbContext
{

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database=CodeFirst501ETicaretDB;Trusted_Connection=True;TrustServerCertificate=Yes");
    }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}