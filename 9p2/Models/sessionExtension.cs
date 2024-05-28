using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace _9p2.Models
{
    public static class sessionExtension
    {
        public static void set<t>(this ISession session, string key, t value)
        {
            session.SetString(key,JsonConvert.SerializeObject(value));
        }
        public static t Get<t>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<t>(value);
        }
    }
}
