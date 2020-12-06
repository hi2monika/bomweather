using System;
using System.Collections.Generic;
using System.Linq;

namespace BOMWeather.Extensions
{
    public static class CommonExtensions
    {
        public static float? GetMedian(this IEnumerable<float> source)
        {
            float[] temp = source.ToArray();
            Array.Sort(temp);
            int count = temp.Length;
            if (count == 0)
            {
                return null;
            }
            else if (count % 2 == 0)
            {
                float a = temp[count / 2 - 1];
                float b = temp[count / 2];
                return (a + b) / 2;
            }
            else
            {
                return temp[count / 2];
            }
        }
    }
}