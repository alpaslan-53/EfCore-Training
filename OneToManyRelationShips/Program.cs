// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");

public class RelationShipsEfCoreDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department>Departments { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database= OneToManyRelationShipEfCoreDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasOne(c => c.Department).WithMany(x => x.Employees).HasForeignKey(x => x.DxId);
    }
}
#region Default Convention
//public class Employee
//{
//    public int Id { get; set; }
//    public string Name { get; set; }
//    public Department Department { get; set; }
//}
//public class Department
//{
//    public int Id { get; set; }
//    public string DepartmanAdi  { get; set; }
//    public ICollection<Employee> Employees { get; set; }
//}
#endregion

#region Data Annotation (foreign keyin ismini kendimiz elle veriyoruz)
//fk ya karılık gelen property name i gelenksel entity kuralların aykırı ise Data Annotation ile mmüdahale ediyoruz
//Burdaki Emlpoyee bağımlı classtır.
//public class Employee
//{
//    public int Id { get; set; }
//    [ForeignKey(nameof(Department))]
//    public  int Schwarz { get; set; }
//    public string Name { get; set; }
//    public Department Department { get; set; }
//}
//public class Department
//{
//    public int Id { get; set; }
//    public string DepartmanAdi { get; set; }
//    public ICollection<Employee> Employees { get; set; }
//}

#endregion

#region FluentAPI
public class Employee
{
    public int Id { get; set; }
   
    public int DxId { get; set; }
    public string Name { get; set; }
    public Department Department { get; set; }
}
public class Department
{
    public int Id { get; set; }
    public string DepartmanAdi { get; set; }
    public ICollection<Employee> Employees { get; set; }
}

#endregion