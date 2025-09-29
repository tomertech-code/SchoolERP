using Newtonsoft.Json;

namespace SchoolERP.UI.Helper
{
    public static class SessionHelper
    {
        public static void SetString(ISession session, string key, string value)
        {
            session.SetString(key, value);
        }

        public static string? GetString(ISession session, string key)
        {
            return session.GetString(key);
        }

        public static void SetInt(ISession session, string key, int value)
        {
            session.SetInt32(key, value);
        }

        public static int? GetInt(ISession session, string key)
        {   
            return session.GetInt32(key);
        }

        public static void Clear(ISession session)
        {
            session.Clear();
        }
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
        public static void ClaerObjectAsJson(this ISession session, string key)
        {
            session.Remove(key);

        }
    }
}
