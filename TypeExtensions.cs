using System;
using System.Linq;

public static class TypeExtensions
{
    /// <summary>
    /// Returns a human-readable name for the type, including generic arguments (e.g., List<TodoTask>).
    /// </summary>
    public static string GetFriendlyName(this Type type)
    {
        if (type.IsGenericType)
        {
            var genericTypeName = type.Name.Substring(0, type.Name.IndexOf('`'));
            var genericArgs = string.Join(", ", type.GetGenericArguments().Select(GetFriendlyName));
            return $"{genericTypeName}<{genericArgs}>";
        }
        return type.Name;
    }
}