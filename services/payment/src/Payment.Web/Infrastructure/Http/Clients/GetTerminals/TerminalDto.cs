using System.Text.Json.Serialization;

namespace Payment.Web.Infrastructure.Http.Clients.GetTerminals;

public record class TerminalDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; init; }
}