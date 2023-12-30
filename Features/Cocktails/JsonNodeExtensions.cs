using System.Text.Json.Nodes;

namespace BlazorHtmxDemo.Extensions;

public static class JsonNodeExtensions
{
    public static string GetString(this JsonNode node)
    {
        return node == null ? "" : node.ToString();
    }

    public static int GetInt32(this JsonNode node)
    {
        var stringValue = node.GetString();

        return string.IsNullOrEmpty(stringValue) ? 0 : Convert.ToInt32(stringValue);
    }
}