namespace Payment.Web.Application.History;

public record class HistoryDto
{
    public IReadOnlyList<OneDayHistory> DayHistories { get; init; }
}

public record OneDayHistory
{
    public DateOnly Date { get; init; }
    public int PurchasedTickets { get; init; }
}