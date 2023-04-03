// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Hello, World!");



public class RelationShipsEfCoreDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAddress> EmployeesAddresses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-E30TBPJ;Database= RelationShipEfCoreDb;Trusted_Connection=True;TrustServerCertificate=Yes");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeAddress>().HasKey(e => e.Id);
        modelBuilder.Entity<Employee>().HasOne(c => c.EmployeeAddress).WithOne(c => c.Employee).HasForeignKey<EmployeeAddress>(c => c.Id);
    }
}

/*Default Convention 
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EmployeeAddress EmployeeAddress { get; set; }

}

public class EmployeeAddress
{
    public int Id { get; set; }
    public int EmployeeId { get; set; } //Foreign keyi olacak employee in. Bağımlı olan classa ID ver.
    public string Address { get; set; }
    public Employee Employee { get; set; }
}

*/

/*DATA Annotation
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EmployeeAddress EmployeeAddress { get; set; }

}

public class EmployeeAddress
{
    public int Id { get; set; }
    [ForeignKey(nameof(Employee))]
    public int Mahmut { get; set; }
    public string Address { get; set; }
    public Employee Employee { get; set; }
}

*/

//Fluent ABI
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EmployeeAddress EmployeeAddress { get; set; }

}

public class EmployeeAddress
{
    public int Id { get; set; }
  
    public string Address { get; set; }
    public Employee Employee { get; set; }
}





