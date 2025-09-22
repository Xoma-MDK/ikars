using Payment.Web.Infrastructure.Http.Clients.GetTerminals;

namespace Payment.Web.Application.Terminals.Implementation;

internal class TerminalService : ITerminalService
{
    private readonly ITerminalHttpClient _terminalHttpClient;

    public TerminalService(ITerminalHttpClient terminalHttpClient)
    {
        _terminalHttpClient = terminalHttpClient;
    }

    public async Task<IEnumerable<Guid>> GetTerminalIdsAsync(CancellationToken cancellationToken)
    {
        return await _terminalHttpClient.GetTerminalIdsAsync(cancellationToken);
    }
}