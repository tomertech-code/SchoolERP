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
    }
}
