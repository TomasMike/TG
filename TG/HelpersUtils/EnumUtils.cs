using System;

namespace TG.HelpersUtils
{
    public static class EnumUtils
    {
        public static T ParseStringToEnum<T>(string text)
            where T : struct
        {
            if (Enum.TryParse(text, out T result))
                return result;

            throw new Exception($"cant parse [{text}] to type [{typeof(T)}]");
        }
    }
}