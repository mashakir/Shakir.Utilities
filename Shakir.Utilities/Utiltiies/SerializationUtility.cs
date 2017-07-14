using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Shakir.Utilities.Utiltiies.Interfaces;

namespace Shakir.Utilities.Utiltiies
{
    /// <summary>
    /// Declare the Serializer Type you want to use.
    /// </summary>
    public enum SerializerType
    {
        Xml, // Use DataContractSerializer
        Json // Use DataContractJsonSerializer
    }
    public class SerializationUtility: ISerializationUtility
    { 
        public T Deserialize<T>(string serializedString, SerializerType useSerializer)
        {
            // Get a Stream representation of the string.
            using (var s = new MemoryStream(Encoding.UTF8.GetBytes(serializedString)))
            {
                T item;
                switch (useSerializer)
                {
                    case SerializerType.Json:
                        // Declare Serializer with the Type we're dealing with.
                        var serJson = new DataContractJsonSerializer(typeof(T));
                        // Read(Deserialize) with Serializer and cast
                        item = (T)serJson.ReadObject(s);
                        break;

                    default:
                        var serXml = new DataContractSerializer(typeof(T));
                        item = (T)serXml.ReadObject(s);
                        break;
                }
                return item;
            }
        }

        public string Serialize<T>(T objectToSerialize, SerializerType useSerializer)
        {
            using (var serialiserStream = new MemoryStream())
            {
                string serialisedString;
                switch (useSerializer)
                {
                    case SerializerType.Json:
                        // init the Serializer with the Type to Serialize
                        var serJson = new DataContractJsonSerializer(typeof(T));
                        // The serializer fills the Stream with the Object's Serialized Representation.
                        serJson.WriteObject(serialiserStream, objectToSerialize);
                        break;

                    default:
                        var serXml = new DataContractSerializer(typeof(T));
                        serXml.WriteObject(serialiserStream, objectToSerialize);
                        break;
                }
                // Rewind the stream to the start so we can now read it.
                serialiserStream.Position = 0;
                using (var sr = new StreamReader(serialiserStream))
                {
                    // Use the StreamReader to get the serialized text out
                    serialisedString = sr.ReadToEnd();
                    sr.Close();
                }
                return serialisedString;
            }
        }
    }
}
