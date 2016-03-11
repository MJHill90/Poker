using Moq;
using NUnit.Framework;
using PokerServer.Engine;

namespace PokerSever.Engine.Tests
{
    [TestFixture]
    public class CardServiceTests : TestBase
    {
        [Test]
        public void GenerateCard_CanGenerate_True()
        {
            var numberGeneratorMock = new Mock<INumberGenerator>();
            numberGeneratorMock.Setup(mock => mock.GenerateRandomByte(It.IsAny<byte>(), It.IsAny<byte>())).Returns(2);

            var cardGenerator = new CardService(numberGeneratorMock.Object);
            ICard card = cardGenerator.GenerateCard();

            Assert.AreEqual(RankEnum.Two, card.Rank, "Expected rank 1");
            Assert.AreEqual(SuitEnum.Hearts, card.Suit, "Expected suit diamonds");
        }
    }
}