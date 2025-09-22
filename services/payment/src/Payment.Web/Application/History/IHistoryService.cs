namespace Payment.Web.Application.History;

public interface IHistoryService
{
    Task<HistoryDto> GetHistoryAsync(Guid terminalId, DateOnly dateFrom, DateOnly dateTo,
        CancellationToken cancellationToken);
}

public interface IHistoryServiceReadRepository
{
    public Task<int> GetPurchasedTicketsCountForDayAsync(Guid terminalId, DateOnly day,
        CancellationToken cancellationToken);
}