namespace Payment.Web.Application.Transactions;

public interface ITransactionService
{
    Task<int> GetCurrentBalance(Guid cardId, CancellationToken cancellationToken);
    Task BuyTicket(Guid cardId, Guid terminalId, CancellationToken cancellationToken);
    Task AddMoney(Guid cardId, int amount, CancellationToken cancellationToken);
}

public interface ITransactionServiceReadRepository
{
    Task<int> GetCurrentBalance(Guid cardId, CancellationToken cancellationToken);
    Task<bool> IsCardExists(Guid cardId, CancellationToken cancellationToken);
}

public interface ITransactionServiceWriteRepository
{
    Task AddNewTransaction(Guid terminalId, Guid cardId, int amount, CancellationToken cancellationToken);
}