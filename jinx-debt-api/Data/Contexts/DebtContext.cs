using jinx_debt_api.Models;
using Microsoft.EntityFrameworkCore;

namespace jinx_debt_api.Data.Contexts;

public class DebtContext : DbContext
{
    public DebtContext(DbContextOptions<DebtContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().ToTable("players").HasKey(p => p.ID);
        modelBuilder.Entity<Debt>().ToTable("debts").HasKey(d => d.ID);
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Debt> Scores { get; set; }
}