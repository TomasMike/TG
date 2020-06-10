using System;

namespace TG.Forms
{
    public static class EnumUtils
    {
        public static T ParseStringToEnum<T>(string text)
            where T :struct
        {
            if (Enum.TryParse<T>(text, out T result))
                return result;

            throw new Exception($"cant parse [{text}] to type [{typeof(T)}]");
        }
    }
}