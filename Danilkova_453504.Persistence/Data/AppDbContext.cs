using Microsoft.EntityFrameworkCore;


namespace Danilkova_453504.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().OwnsOne<SongDetails>(t => t.SongInformation);
        }
    }
}
