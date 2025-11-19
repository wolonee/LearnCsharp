using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NotesApp_2.Data.Entities;

namespace NotesApp_2.Data;

public class AppDbContext : DbContext
{
    public DbSet<Note> Notes => Set<Note>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("AppNotes.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Notes)
            .WithOne(n => n.Category)
            .HasForeignKey(n => n.Category)
            .OnDelete(DeleteBehavior.Restrict);
    }
}