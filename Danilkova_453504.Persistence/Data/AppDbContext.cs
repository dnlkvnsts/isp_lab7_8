using Microsoft.EntityFrameworkCore;


namespace Danilkova_453504.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Singer> Singers { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().OwnsOne<SongDetails>(t => t.SongInformation);
        }
    }
}
