namespace Payment.Web.Infrastructure.Http.Clients.GetTerminals;

internal class TerminalHttpClient : BaseHttpClient, ITerminalHttpClient
{
    public TerminalHttpClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<IEnumerable<Guid>> GetTerminalIdsAsync(CancellationToken cancellationToken)
    {
        var terminals = await GetAsync<IEnumerable<TerminalDto>>("terminals");

        return terminals.Select(t => t.Id);
    }
}
