using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain.Entites;

namespace WebApplication1.infraestructure.persistence
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
