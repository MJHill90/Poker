using System.IO;
using System.Xml.Serialization;

namespace PokerServer.Engine.Configuration
{
    public class PersistableObject : IPersistableObject
    {
        public T Load<T>(string fileName) where T : PersistableObject, new()
        {
            T result;

            using (FileStream stream = File.OpenRead(fileName))
            {
                result = new XmlSerializer(typeof(T)).Deserialize(stream) as T;
            }

            return result;
        }

        public void Save<T>(string fileName) where T : PersistableObject
        {
            using (FileStream stream = new FileStream(fileName, FileMode.CreateNew))
            {
                new XmlSerializer(typeof(T)).Serialize(stream, this);
            }
        }
    }
}
