using System.ComponentModel.Design;

namespace BOMWeather.Extensions
{
    public static class FloatExtensions
    {
        public static float ToFloat(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return default;

            return float.TryParse(value, out var f) ? f : default;
        }
    }
}