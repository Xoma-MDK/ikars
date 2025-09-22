using Microsoft.EntityFrameworkCore;
using Payment.Web.Application.GetCards;

namespace Payment.Web.Infrastructure.Database.Repositories.GetCards;

internal class GetCardServiceReadRepository : IGetCardServiceReadRepository
{
    private PaymentDbContext _dbContext;

    public GetCardServiceReadRepository(PaymentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Card>> GetAllCards()
    {
        return await _dbContext.Cards.ToListAsync();
    }
}