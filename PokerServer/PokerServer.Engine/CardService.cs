namespace PokerServer.Engine
{
    public class CardService : ICardService
    {
        private readonly INumberGenerator _numberGenerator;

        public CardService(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }

        public ICard GenerateCard()
        {
            byte randomRankNum = _numberGenerator.GenerateRandomByte(2, 14);
            byte randomSuitEnum = _numberGenerator.GenerateRandomByte(0, 3);
            RankEnum rank = (RankEnum)randomRankNum;
            SuitEnum suit = (SuitEnum) randomSuitEnum;
            return new Card(rank, suit);
        }

        public ICard GenerateCard(RankEnum rank, SuitEnum suit)
        {
            return new Card(rank, suit);
        }
    }
}