namespace PokerServer.Engine
{
    public interface IDeckService
    {
        IDeck<ICard> CreateDeck(bool shuffle);
    }
}