using JsonFx.Json;

static public class Json<T>
{
    static public string Write(T data)
    {
        return JsonWriter.Serialize(data);
    }

    static public T Read(string json)
    {
        return JsonReader.Deserialize<T>(json);
    }
}
