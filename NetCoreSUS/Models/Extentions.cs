using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NetCoreSUS.Models
{
    public static class SessionExtensions
        {
            public static void SetObjectAsJson(this ISession session, string key, object value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }

            public static T GetObjectFromJson<T>(this ISession session, string key)
            {
                var value = session.GetString(key);

                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
        }
    public static class Extentions
    {
        

        public static string Reverse(this string source)
        {
            var ary = source.ToCharArray();
            Array.Reverse(ary);
            return new string(ary);
        }

        public static string GetScoreText(this int value, bool reverseScore)
        {
            if (reverseScore)
            {
                switch (value)
                {
                    case 0:
                        return "Strongly disagree";
                    case 1:
                        return "Disagree";
                    case 2:
                        return "No opinion";
                    case 3:
                        return "Agree";
                    default:
                        return "Strongly agree";
                }
            }
            else
            {
                switch (value)
                {
                    case 0:
                        return "Strongly agree";
                    case 1:
                        return "Agree";
                    case 2:
                        return "No opinion";
                    case 3:
                        return "Disagree";
                    default:
                        return "Strongly disagree";
                }
            }
        }
        
    }
}
