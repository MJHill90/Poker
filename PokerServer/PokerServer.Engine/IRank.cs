namespace PokerServer.Engine
{
    public interface IRank
    {
        RankEnum Rank { get; }
        byte RankValue { get; }
    }
}