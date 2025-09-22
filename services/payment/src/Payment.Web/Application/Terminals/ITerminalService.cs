namespace Payment.Web.Application.Terminals;

public interface ITerminalService
{
    Task<IEnumerable<Guid>> GetTerminalIdsAsync(CancellationToken cancellationToken);
}