using jinx_debt_api.Models;
using Microsoft.EntityFrameworkCore;

namespace jinx_debt_api.Data.Contexts;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().ToTable("Player").HasKey(p => p.ID);
        modelBuilder.Entity<Game>().ToTable("Game").HasKey(d => d.ID);
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Game> Games { get; set; }
}