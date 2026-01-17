using Microsoft.EntityFrameworkCore;
using MiniNotion.Core.Entities;

namespace MiniNotion.Data;

public class AppDbContext : DbContext
{
    public DbSet<Page> Pages { get; set; } = null!;
    public DbSet<PageContent> PageContents { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var dbPath = Path.Combine(
                AppContext.BaseDirectory,
                "MiniNotion.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Page>()
            .HasOne(p => p.Content)
            .WithOne(c => c.Page)
            .HasForeignKey<PageContent>(c => c.PageId);
    }
}
