using Payment.Web.Infrastructure.Http.Clients.GetTerminals;

namespace Payment.Web.Infrastructure.Http;

public static class ServiceExtensions
{
    public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration config)
    {
        var terminalServerBaseAddress = config.GetValue<string>("HttpClientSettings:TerminalServerBaseAddress");
        
        ArgumentNullException.ThrowIfNull(terminalServerBaseAddress);
        
        services.AddHttpClient<ITerminalHttpClient, TerminalHttpClient>(client =>
        {
            client.BaseAddress = new Uri(terminalServerBaseAddress);
        });
        
        return services;
    }
}