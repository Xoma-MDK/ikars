using Payment.Web.Application.History;

namespace Payment.Web.Controllers;

internal static class HistoryController
{
    public static WebApplication MapHistoryApi(this WebApplication app)
    {
        app.MapHistory();
        return app;
    }

    private static WebApplication MapHistory(this WebApplication app)
    {
        app.MapGet("/history/{terminalId:guid}",
            async (
                IHistoryService historyService,
                DateOnly dateFrom,
                DateOnly dateTo,
                Guid terminalId,
                CancellationToken cancellationToken) => await historyService.GetHistoryAsync(terminalId, dateFrom, dateTo, cancellationToken));

        return app;
    }
}