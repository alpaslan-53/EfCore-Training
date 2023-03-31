// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

Console.WriteLine("Hello, World!");
Console.WriteLine();
#region Veri Ekleme
DbFirstKitaplık501DbContext context = new();
//Book book = new()
//{
//    KitapAdi = "Muhittin",
//    Fiyat = 60
//};

//context.Add(book);
//context.SaveChanges();
////context.SaveChanges();
//await context.SaveChangesAsync();
#region Birden Fazla Veri Eklerken Nelere Dikkat Edeceğiz

//Book book = new()
//{
//    KitapAdi = "Muhittin3",
//    Fiyat = 50

//};
//Book book1 = new()
//{
//    KitapAdi = "Ökkeş Dolmuşçu",
//    Fiyat = 60

//};

//Book book2 = new()
//{
//    KitapAdi = "Yunus Günçe",
//    Fiyat = 70

//};

//context.Books.Add(book);
//context.Books.Add(book1);
//context.Books.Add(book2);
//context.Books.AddRange(book1, book, book2);

await context.SaveChangesAsync();

#endregion


//Book book1 = await context.Books.FirstOrDefaultAsync(u => u.Id == 5);
//Console.WriteLine(context.Entry(book1).State);

//book1.KitapAdi = "Tuna Tavus";
//Console.WriteLine(context.Entry(book1).State);

//await context.SaveChangesAsync();
//Console.WriteLine(context.Entry(book1).State);



Book bookOrnek = new()
{
    Id = 1,
    KitapAdi = "Karpuz",
    Fiyat = 799
};
context.Books.Update(bookOrnek);
//ChangeTracker mekanizması tarafından takip edilemeyen nesnelerin güncellenebilmesi açısından update fonksiyonu kullnaılmaktadır. bu takip edilememe meselesini şöyle algılayabilirz.İlk yaptığımız güncelleme örneğinde veritabanımıza context üzerinden bir sorgu atıp isteidğimiz Id ye sahip olan nesneyi programımıza çağırdık.Sonrasında bu gelen ve haliyle takip edilen nesen üzerinde degişiklik yapıp savechanges dedik.ŞUan ise context üzerinde herhangi bir değişiklik ypamadan ve haliyle taikp edemediğimiz bir nesne üzerine işlem yapmak istedik bu yüzden update metodu kullanmak zorunda kaldık.
//await context.SaveChangesAsync();



var kitaplar = await context.Books.ToListAsync();
foreach(var item in kitaplar)
{
    item.KitapAdi += " :)";
}
await context.SaveChangesAsync();






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