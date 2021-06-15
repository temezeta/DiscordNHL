using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public static class LinqExtensions
    {
        private const int MIN_MATCH_LENGTH = 3;

        public static T GetClosestMatch<T>(this IEnumerable<T> source, string searchString, Func<T, string> keySelector) where T : class
        {
            if (source == null || searchString.Length < MIN_MATCH_LENGTH)
            {
                return null;
            }

            var longestFound = 0;

            var bestMatch = source.MaxBy(it => 
            {
                var substringLength = searchString.LongestCommonSubstring(keySelector(it)).Length;
                longestFound = Math.Max(longestFound, substringLength);
                return substringLength;
            }
            ).FirstOrDefault();

            return longestFound >= MIN_MATCH_LENGTH ? bestMatch : null;
        }

        public static string LongestCommonSubstring(this string value, string toCompare)
        {
            var lengths = new int[value.Length, toCompare.Length];

            int maxLength = 0;
            string result = "";
            for (int i = 0; i < value.Length; i++)
            {
                for (int j = 0; j < toCompare.Length; j++)
                {
                    if (value[i] == toCompare[j])
                    {
                        lengths[i, j] = i == 0 || j == 0 ? 1 : lengths[i - 1, j - 1] + 1;
                        if (lengths[i, j] > maxLength)
                        {
                            maxLength = lengths[i, j];
                            result = value.Substring(i - maxLength + 1, maxLength);
                        }
                    }
                    else
                    {
                        lengths[i, j] = 0;
                    }
                }
            }
            return result;
        }
    }
}
