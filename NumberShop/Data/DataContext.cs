using Microsoft.EntityFrameworkCore;
using NumberShop.Models;

namespace NumberShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Parfum> Parfums { get; set; }

        public DbSet<Categories> Categories { get; set; }
    }
}
