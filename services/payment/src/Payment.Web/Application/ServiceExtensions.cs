using Payment.Web.Application.GetCards;
using Payment.Web.Application.GetCards.Implementation;
using Payment.Web.Application.History;
using Payment.Web.Application.History.Implementation;
using Payment.Web.Application.Terminals;
using Payment.Web.Application.Terminals.Implementation;
using Payment.Web.Application.Transactions;
using Payment.Web.Application.Transactions.Implementation;

namespace Payment.Web.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGetCardService, GetCardService>();

        services.AddScoped<ITransactionService, TransactionService>();

        services.AddScoped<ITerminalService, TerminalService>();

        services.AddScoped<IHistoryService, HistoryService>();

        return services;
    }
}