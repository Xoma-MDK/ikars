using Payment.Web.Application.GetCards;
using Payment.Web.Application.History;
using Payment.Web.Application.Transactions;
using Payment.Web.Infrastructure.Database.Repositories.GetCards;
using Payment.Web.Infrastructure.Database.Repositories.History;
using Payment.Web.Infrastructure.Database.Repositories.Transactions;

namespace Payment.Web.Infrastructure.Database;

public static class ServiceExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<PaymentDbContext>();
        
        services.AddScoped<IGetCardServiceReadRepository, GetCardServiceReadRepository>();

        services.AddScoped<ITransactionServiceWriteRepository, TransactionServiceWriteRepository>();
        services.AddScoped<ITransactionServiceReadRepository, TransactionServiceReadRepository>();

        services.AddScoped<IHistoryServiceReadRepository, HistoryServiceReadRepository>();
        
        return services;
    }
}