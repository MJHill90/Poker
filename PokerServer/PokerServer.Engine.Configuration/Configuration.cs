namespace PokerServer.Engine.Configuration
{
    public class Configuration : PersistableObject, IConfiguration
    {
        public int DeckSize { get; set; }
    }
}