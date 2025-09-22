using Microsoft.EntityFrameworkCore;

namespace Payment.Web.Infrastructure.Database;

internal class PaymentDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    private readonly IConfiguration _configuration;

    public PaymentDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PaymentWebDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Transaction>()
            .HasOne(e => e.Card)
            .WithMany(e => e.Transactions)
            .HasForeignKey(e => e.CardId)
            .IsRequired();
        base.OnModelCreating(modelBuilder);
    }
}

public class Card
{
    public Guid Id { get; init; }
    public ICollection<Transaction> Transactions { get; } = [];
}

public class Transaction
{
    public Guid Id { get; init; }
    public Guid CardId { get; init; }
    public Card Card { get; init; } = null!;
    public int Amount { get; init; }
    public DateTimeOffset Timestamp { get; init; }
    public Guid TerminalId { get; init; }
}