using Microsoft.EntityFrameworkCore;
using Payment.Web.Application.History;

namespace Payment.Web.Infrastructure.Database.Repositories.History;

internal class HistoryServiceReadRepository : IHistoryServiceReadRepository
{
    private readonly PaymentDbContext _dbContext;

    public HistoryServiceReadRepository(PaymentDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<int> GetPurchasedTicketsCountForDayAsync(Guid terminalId, DateOnly day, CancellationToken cancellationToken)
    {
        return _dbContext.Transactions
            .Where(t =>
                t.TerminalId == terminalId &&
                t.Timestamp.Date == day.ToDateTime(new TimeOnly(0, 0)) &&
                t.Amount < 0)
            .CountAsync(cancellationToken);
    }
    
    private static bool IsBetween(DateTimeOffset dateTimeOffset, DateOnly startDate, DateOnly endDate)
    {
        // Преобразуем DateOnly в DateTime
        DateTime startDateTime = startDate.ToDateTime(TimeOnly.MinValue);
        DateTime endDateTime = endDate.ToDateTime(TimeOnly.MaxValue);

        // Проверяем, находится ли DateTimeOffset в диапазоне
        return dateTimeOffset.DateTime >= startDateTime && dateTimeOffset.DateTime <= endDateTime;
    }
}

internal static class DateTimeOffsetHelper
{
}