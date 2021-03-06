using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Script.Utils
{
    public static class BinaryUtil
    {
        public static byte[] SerializeObject(object o)
        {
            if (!o.GetType().IsSerializable)
            {
                return null;
            }

            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, o);
                return stream.ToArray();
            }
        }

        public static object DeserializeObject(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                return new BinaryFormatter().Deserialize(stream);
            }
        }
    }
}