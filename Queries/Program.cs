// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

Console.WriteLine("");

Ecommerc501Dbcontext context = new();



//for (int i = 0; i < 500; i++)
//{
//    Product p = new Product();
//    p.Name = $"Ürün {i + 1}";
//    p.Price = i * 10;
//    context.Products.Add(p);

//}

//context.SaveChanges();

#region En Temel Şekilde Sorgu Kullanımı

#region Method Syntax
//var products = context.Products.ToList();
//foreach (var item in products)
//{
//    Console.WriteLine($"Ürün adı: {item.Name} / Ürün Fiytı: {item.Price}");
//}
#endregion

#region Query Syntax

//var urunler = await (from x in context.Products select x).ToListAsync();

//foreach (var item in urunler)
//{
//    Console.WriteLine($"Ürün adı: {item.Name} / Ürün Fiytı: {item.Price}");
//}


#endregion

#endregion

#region Gecikmeli Execution (Deferred Execution) --> foreach
//var urunId = 200;
//var products = from x in context.Products where x.Id > urunId && x.Price > 400 select x;

//urunId = 300;

//foreach (var item in products)
//{
//    Console.WriteLine(item.Name + " / " + item.Id + " / " +item.Price );
//}


#endregion

#region Çoğul Veri Getiren Sorgulamalar

#region Where
//Oluşturulan sorguya şart eklemeyi sağlar.

#region Method Syntax
//var products = context.Products.Where(u => u.Id > 350 ).ToList();

//var products2 = await context.Products.Where(u => u.Name.EndsWith("2")).ToListAsync();

//foreach (var item in products2)
//{
//    Console.WriteLine(item.Name); 
//}
#endregion

#region QuerySyntax
//var urunler = from x in context.Products 
//              where x.Id > 250 && x.Name.EndsWith("2") 
//              select x;

//foreach (var item in urunler)
//{
//    Console.WriteLine(item.Name); 
//}
#endregion
#endregion

#region Queryable ve Numarable arasındaki fark nedir?
//Queryable --> Sorguya karşılık gelir. Efcore üzerinde yapılmış olan sorgunun execute edilmemiş halidir.

//Numerable --> Sorgunun  çalıştırılıp execute edilip verilerin in memory'e yüklenmiş halini ifad eder.
#endregion



#region OrderBy

#region Method
//var products = context.Products.Where(u => u.Id > 350).OrderBy(x => x.Price).ToList();

//foreach (var product in products)
//{
//    Console.WriteLine($"{product.Name} / {product.Price}");
//}
#endregion

#region Query 
//var products = from x in context.Products
//               where x.Id > 350
//               orderby x.Price
//               select x;
//var urunler = products.ToList();
//foreach (var product in urunler)
//{
//    Console.WriteLine($"{product.Name} / {product.Price}");
//}
#endregion


#endregion


#region ThenBy (Ascending)

#region Method Syntax
//var products = context.Products.Where(x => x.Id > 350).OrderBy(x => x.Name).ThenBy(o => o.Price).ToList();

//foreach (var item in products)
//{
//    Console.WriteLine($"{item.Name} / {item.Price} TL");
//}
#endregion



#endregion


#region Order By Descending / Then By Descending
//var products = context.Products.Where(x => x.Id > 350).OrderByDescending(x => x.Name).ThenByDescending(o => o.Price).ToList();

//foreach (var item in products)
//{
//    Console.WriteLine($"{item.Name} / {item.Price} TL");
//}




#endregion

#endregion

#region Tekil Veri Getiren Sorgulamalar

#region Single / SingleAsync
//var product = await context.Products.SingleAsync(u => u.Id == 25);
//Console.WriteLine(product.Name + " / " + product.Price);

//Birden çok kayıt geldiğinde ya da hiç kayıt gelmediğinde exeption furlatır.
//var product = await context.Products.SingleAsync(u => u.Id > 350);
//Console.WriteLine(product.Name + " / " + product.Price);
#endregion

#region SingleOrDefault
//SingleOrDef'ta çoklu veri gelirse excepton fırlar, fakat öyle bir kayıt hiç yoksa konsol null şekilde bir dönüş sağlar. 
//var product = await context.Products.SingleOrDefaultAsync(u => u.Id > 150);

//var product = await context.Products.SingleOrDefaultAsync(u => u.Id == 150);
//Console.WriteLine(product.Name);
#endregion

#region First / FirstOrDefault

//var product = await context.Products.FirstAsync(u => u.Id== 1);
//Console.WriteLine(product.Name);

//Eşleşen kayıt yok -> Exception var
//var product = await context.Products.FirstAsync(u => u.Id == 6000);

//Eşleşen birden fazla kayıt var. EŞleşen ilk kayıdı getirecektir.
//var product = await context.Products.FirstAsync(u => u.Id > 150);
//Console.WriteLine(product.Name);


//Kayıt olmasa dahi null döner.
//var product = await context.Products.FirstOrDefaultAsync(x => x.Id == 6000);



#endregion

#region Find
//Kayıt yoksa null döner. KAyıt varsa firstordefault gibi çalışır sadece kısaca parametre olarak id yollarız. 
//var x = context.Products.Find(5500);
//Console.WriteLine(x.Name);
#endregion

#region Last
//Last son kayıdı getirir. 
//Aşağıdaki örnekte order by ile beraber bir kullanım deneyimi yaşadık. Last sonrasında id'si 350'den büyük olan ürünleri sıraladı. Normalde yapacağı şey sonuncu ürünü getirmekti. Fakat biz bu sorguya bir de order by descending eklediğimiz için ve bu sırlamada ürün fiyatını sondan başa sıralamış olduğumuz için son kayıt olarak ürün fiyatı en düşük olan ve id'si 350'den büyük olan ilk ürünü getirmiş oldu.
//var urun = context.Products.OrderByDescending(x => x.Price).LastOrDefault( x => x.Id> 350);
//Console.WriteLine(urun.Name + "/" + urun.Price);
#endregion



#endregion

#region Diğer Fonksiyonlar

#region Count
//var urunler =  (await context.Products.ToListAsync()).Count();
//Console.WriteLine(urunler);

//var urunler = (await context.Products.ToListAsync()).LongCount();
//Console.WriteLine(urunler);
#endregion









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