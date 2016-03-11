namespace PokerServer.Engine.Configuration
{
    public interface IPersistableObject
    {
        T Load<T>(string fileName) where T : PersistableObject, new();
        void Save<T>(string fileName) where T : PersistableObject;
    }
}