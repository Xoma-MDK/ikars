using System.Data;
using Microsoft.EntityFrameworkCore;
using Payment.Web.Application.Transactions;

namespace Payment.Web.Infrastructure.Database.Repositories.Transactions;

internal class TransactionServiceWriteRepository : ITransactionServiceWriteRepository
{
    private readonly PaymentDbContext _context;

    public TransactionServiceWriteRepository(PaymentDbContext context)
    {
        _context = context;
    }

    public async Task AddNewTransaction(Guid terminalId, Guid cardId, int amount, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var balance = await _context.Transactions
                .Where(t => t.CardId == cardId)
                .SumAsync(t => t.Amount, cancellationToken);

            if (balance + amount < 0)
            {
                throw new Exception();
            }
            
            _context.Transactions.Add(new Transaction
            {
                Amount = amount,
                CardId = cardId,
                Id = Guid.NewGuid(),
                TerminalId = terminalId,
                Timestamp = DateTimeOffset.UtcNow
            });
            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}