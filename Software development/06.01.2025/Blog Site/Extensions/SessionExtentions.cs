using System.Text.Json;

namespace Blog_Site.Extensions
{
    public static class SessionExtentions
    {
        public static void SetObject<T>(this ISession session, string key, T data)
            where T : class
        {
            if (data == null)
            {
                session.Remove(key);
                return;
            }

            string jsonResult = JsonSerializer.Serialize(data);

            session.SetString(key, jsonResult);
        }

        public static T GetObject<T>(this ISession session, string key)
            where T : class
        {
            string jsonData = session.GetString(key)!;

            if (jsonData == null)
                return null!;

            return JsonSerializer.Deserialize<T>(jsonData)!;
        }
    }
}
