using System.Text.Json;

public static class SessionExtensions
{
    public static void SetObjectAsJson<T>(this ISession session, object value)
    {
        // Use the friendly type name as the key
        session.SetString(typeof(T).GetFriendlyName(), JsonSerializer.Serialize(value));
    }

    public static T GetObjectFromJson<T>(this ISession session)
    {
        var value = session.GetString(typeof(T).GetFriendlyName());
        return (value == null ? Activator.CreateInstance<T>() : JsonSerializer.Deserialize<T>(value))!;
    }
}
