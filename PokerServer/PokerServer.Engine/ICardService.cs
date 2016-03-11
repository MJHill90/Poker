namespace PokerServer.Engine
{
    public interface ICardService
    {
        ICard GenerateCard();
        ICard GenerateCard(RankEnum rank, SuitEnum suit);
    }
}