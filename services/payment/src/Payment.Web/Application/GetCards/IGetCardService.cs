using Payment.Web.Infrastructure.Database;

namespace Payment.Web.Application.GetCards;

public interface IGetCardService
{
    public Task<IEnumerable<Guid>> GetAllCardsIdAsync();
}

public interface IGetCardServiceReadRepository
{
    public Task<IEnumerable<Card>> GetAllCards();
}