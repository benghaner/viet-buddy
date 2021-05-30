using System.Text.Json;

namespace VietBuddy.Shared
{
    public interface IJsonClonable {}
    public static class JsonExtensions
    {
        public static T Clone<T>(this T original) where T : IJsonClonable
        {
            string json = JsonSerializer.Serialize<T>(original);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}