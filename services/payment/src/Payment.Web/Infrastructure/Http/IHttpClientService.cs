namespace Payment.Web.Infrastructure.Http;

public interface IHttpClientService
{
    Task<TResponse> GetAsync<TResponse>(string url);
    Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request);
}