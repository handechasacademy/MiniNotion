using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using MiniNotion.Core.Entities;

namespace MiniNotion.Data;

public class AppDbContext : DbContext
{
    public DbSet<Page> Pages { get; set; } = null!;
    public DbSet<PageContent> PageContents { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=MiniNotionDb;Trusted_Connection=True;TrustServerCertificate=True;");
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
