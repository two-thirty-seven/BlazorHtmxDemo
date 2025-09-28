using System.Text.Json;

public static class SessionExtensions
{
    public static void SetObjectAsJson<T>(this ISession session, string key, object value)
    {
        // Use the friendly type name as the key
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return (value == null ? Activator.CreateInstance<T>() : JsonSerializer.Deserialize<T>(value))!;
    }
}
