using EntityFramework_classwork.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_classwork.Data;

public class TrainsDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Train> Trains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        #warning Hide sensitive information

        string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=TrainManagementDatabase;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";
        
        optionsBuilder.UseSqlServer(connectionString);
        
    }
}