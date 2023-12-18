using System.Buffers.Text;
using Microsoft.EntityFrameworkCore;
using Realitky.Models.Entity;
using Type = Realitky.Models.Entity.Type;

namespace WebApplication4.Models;

public class MyContext : DbContext
{
    public DbSet<Gallery> Gallery { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Parametrs> Parametrs { get; set; }
    public DbSet<ParametrsOffers> ParametrsOffers { get; set; }
    public DbSet<Region> Region { get; set; }
    public DbSet<Request> Request { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Type> Type { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Favorite> Favorite { get; set; }
    public DbSet<Request_user> Threads{ get; set; }
    public DbSet<Message> Messages { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string name = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("ZG9sYW5za3lhZGFt"));
        optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;" +
                                $"database=4b2_{name}_db1;" +
                                $"user={name};" +
                                "password=123456;" +
                                "SslMode=none");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define composite key for ParametrOffer
        modelBuilder.Entity<ParametrsOffers>()
            .HasKey(po => new { po.IdOffer, po.IdParametr });

        // Configure the many-to-many relationship
        modelBuilder.Entity<ParametrsOffers>()
            .HasOne(po => po.Offer)
            .WithMany(b => b.ParametrsOffers)
            .HasForeignKey(po => po.IdOffer);

        modelBuilder.Entity<ParametrsOffers>()
            .HasOne(po => po.Parametr)
            .WithMany(c => c.ParametrsOffers)
            .HasForeignKey(po => po.IdParametr);
    }
}
