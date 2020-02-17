namespace IRunes.Data
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;

    public class RunesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=IRunes;Integrated Security=True;");
        }
    }
}
