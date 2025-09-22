namespace Payment.Web.Application.History.Implementation;

internal class HistoryService : IHistoryService
{
    private readonly IHistoryServiceReadRepository _historyServiceReadRepository;

    public HistoryService(IHistoryServiceReadRepository historyServiceReadRepository)
    {
        _historyServiceReadRepository = historyServiceReadRepository;
    }

    public async Task<HistoryDto> GetHistoryAsync(
        Guid terminalId,
        DateOnly dateFrom,
        DateOnly dateTo,
        CancellationToken cancellationToken)
    {
        if (dateFrom > dateTo)
        {
            throw new Exception();
        }

        List<OneDayHistory> result = [];

        foreach (var date in GetDatesBetween(dateFrom, dateTo))
        {
            var purchasedTickets = await _historyServiceReadRepository.GetPurchasedTicketsCountForDayAsync(
                terminalId,
                date,
                cancellationToken);

            result.Add(new OneDayHistory
            {
                Date = date,
                PurchasedTickets = purchasedTickets,
            });
        }

        return new HistoryDto
        {
            DayHistories = result,
        };
    }

    private static List<DateOnly> GetDatesBetween(DateOnly start, DateOnly end)
    {
        List<DateOnly> dates = [];

        for (var date = start; date <= end; date = date.AddDays(1))
        {
            dates.Add(date);
        }

        return dates;
    }
}