using System.Text.Json;

public static class SessionExtensions
{
  public static void SetObjectAsJson<T>(this ISession session, object value)
  {
      session.SetString(typeof(T).Name, JsonSerializer.Serialize(value));
  }
  
  public static T GetObjectFromJson<T>(this ISession session)
  {
      var value = session.GetString(typeof(T).Name);
      return value == null ? Activator.CreateInstance<T>() : JsonSerializer.Deserialize<T>(value);
  }
}
