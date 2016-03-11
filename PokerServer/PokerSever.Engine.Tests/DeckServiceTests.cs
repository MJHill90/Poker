using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PokerServer.Engine;

namespace PokerSever.Engine.Tests
{
    [TestFixture]
    public class DeckServiceTests
    {
        [Test]
        public void CreateDeck_IsCreated_True()
        {
            var cardServiceMock = new Mock<ICardService>();
            var numberGeneratorMock = new Mock<INumberGenerator>();
            var deckService = new DeckService(cardServiceMock.Object, numberGeneratorMock.Object);
            IDeck<ICard> deck = deckService.CreateDeck(false);
            int expectedCardCount = 52;
            Assert.AreEqual(expectedCardCount, deck.Count, string.Format("Deck does not contain {0} cards", expectedCardCount));
        }

        [Test]
        public void CreateDeck_AllUnique_True()
        {
            var cardServiceMock = new Mock<ICardService>();
            var numberGeneratorMock = new Mock<INumberGenerator>();
            var deckService = new DeckService(cardServiceMock.Object, numberGeneratorMock.Object);
            IDeck<ICard> deck = deckService.CreateDeck(false);

            // Group by rank and suit 
            IEnumerable<IGrouping<dynamic, ICard>> groupedDeck = deck.Cards.GroupBy(x => new { x.Rank, x.Suit });

            // Expected group count should be the same as the deck size
            // To prove that the deck has all unique values
            int expectedGroupedCount = 52;

            Assert.AreEqual(expectedGroupedCount, groupedDeck.Count(), "Deck does not contain all unique cards");
        }

        [Test]
        public void CreateDeck_ShuffledTrue_IsShuffled()
        {
            var numberGeneratorMock =
                new Mock<INumberGenerator>();
            numberGeneratorMock.Setup(mock => mock.GenerateRandomDouble(0, 1)).Returns(1);
            var deckService = new DeckService(new CardService(new NumberGenerator()), numberGeneratorMock.Object);

            // Create a shuffled deck
            IDeck<ICard> deck = deckService.CreateDeck(true);

            Assert.AreEqual(new Card(RankEnum.Ace, SuitEnum.Spades), deck.Cards[0]);

            Assert.AreEqual(new Card(RankEnum.King, SuitEnum.Spades), deck.Cards[51]);
        }
    }
}