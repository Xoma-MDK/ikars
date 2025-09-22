using FluentAssertions;
using NSubstitute;
using Payment.Web.Application.GetCards;
using Payment.Web.Application.GetCards.Implementation;
using Payment.Web.Infrastructure.Database;

namespace Payment.Tests.Application;

public class GetCardsServiceTests
{
    private readonly IGetCardService _service;
    private readonly IGetCardServiceReadRepository _repository;

    private readonly Guid _cardId = Guid.NewGuid();
    
    public GetCardsServiceTests()
    {
        _repository = Substitute.For<IGetCardServiceReadRepository>();
        
        ConfigureRepository([GetCard(_cardId)]);
        
        _service = new GetCardService(_repository);
    }
    
    [Fact]
    public async Task GetAllCardsIdAsync_OneCard_ReturnsAllCards()
    {
        var cards = (await _service.GetAllCardsIdAsync()).ToList();

        cards.Should().NotBeEmpty();
        cards.Count.Should().Be(1);
    }

    [Fact]
    public async Task GetAllCardsIdAsync_EmptyList_ReturnsEmptyList()
    {
        ConfigureRepository([]);

        var cards = (await _service.GetAllCardsIdAsync()).ToList();

        cards.Count.Should().Be(0);
    }

    private void ConfigureRepository(IReadOnlyList<Card> cards)
    {
        _repository.GetAllCards().Returns(cards);
    }

    private Card GetCard(Guid id)
    {
        return new Card()
        {
            Id = id,
        };
    }
}