namespace Payment.Web.Infrastructure.Http.Clients.GetTerminals;

public interface ITerminalHttpClient
{
    Task<IEnumerable<Guid>> GetTerminalIdsAsync(CancellationToken cancellationToken);
}