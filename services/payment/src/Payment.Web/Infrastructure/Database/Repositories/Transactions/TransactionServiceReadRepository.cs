using Microsoft.EntityFrameworkCore;
using Payment.Web.Application.Transactions;

namespace Payment.Web.Infrastructure.Database.Repositories.Transactions;

internal class TransactionServiceReadRepository : ITransactionServiceReadRepository
{
    private readonly PaymentDbContext _context;

    public TransactionServiceReadRepository(PaymentDbContext context)
    {
        _context = context;
    }

    public async Task<int> GetCurrentBalance(Guid cardId, CancellationToken cancellationToken)
    {
        var balance = await _context.Transactions
            .Where(t => t.CardId == cardId)
            .SumAsync(t => t.Amount, cancellationToken);

        return balance;
    }

    public async Task<bool> IsCardExists(Guid cardId, CancellationToken cancellationToken)
    {
        return await _context.Cards.AnyAsync(c => c.Id == cardId, cancellationToken);
    }
}