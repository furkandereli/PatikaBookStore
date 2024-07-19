using Microsoft.EntityFrameworkCore;
using PatikaBookStore.Entities;

namespace PatikaBookStore.Context
{
    public class PatikaDbContext : DbContext
    {
        public PatikaDbContext(DbContextOptions<PatikaDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
