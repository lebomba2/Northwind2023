using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    //add a new db set for the discount class 

    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public void AddCustomer(Customer customer)
    {
        this.Add(customer);
        this.SaveChanges();
    }
}