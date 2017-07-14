namespace Shakir.Utilities.Utiltiies.Interfaces
{
    public interface ISerializationUtility
    {
        string Serialize<T>(T objectToSerialize, SerializerType useSerializer);
        T Deserialize<T>(string serializedString, SerializerType useSerializer);
    }
}
