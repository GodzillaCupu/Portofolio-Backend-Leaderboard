using Microsoft.EntityFrameworkCore;
using Leaderboard.Api.Models;

namespace Leaderboard.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Player> Players => Set<Player>();
    public DbSet<ScoreEntry> ScoreEntries => Set<ScoreEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasIndex(p => p.Username).IsUnique();
        });

        modelBuilder.Entity<ScoreEntry>(entity =>
        {
            entity.HasOne(s => s.Player)
                  .WithMany(p => p.Scores)
                  .HasForeignKey(s => s.PlayerId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(s => s.Score);
        });
    }
}