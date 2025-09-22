namespace Payment.Web.Infrastructure.Http.Clients.GetTerminals;

internal class FakeTerminalHttpClient : BaseHttpClient, ITerminalHttpClient
{
    public FakeTerminalHttpClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public Task<IEnumerable<Guid>> GetTerminalIdsAsync(CancellationToken cancellationToken)
    {
        var list = new List<Guid>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(Guid.NewGuid());
        }

        return Task.FromResult<IEnumerable<Guid>>(list);
    }
}