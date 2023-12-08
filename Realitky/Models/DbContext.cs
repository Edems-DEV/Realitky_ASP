using System.Buffers.Text;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class MyContext : DbContext
    {
        // public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string name = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("RG9sYW5za3lBZGFt"));
            optionsBuilder.UseMySQL("server=mysqlstudenti.litv.sssvt.cz;" +
                                    $"database={name}_db1;" +
                                    $"user={name};" +
                                    "password=123456;" +
                                    "SslMode=none");
        }
    }
}