using System;
using System.Text.RegularExpressions;

namespace NHLStats.Helpers
{
    public static class SeasonYearHelper
    {
        private static readonly Regex CorrectRegex = new(@"^[0-9]{8}$");
        private static readonly Regex LongFormRegex = new(@"^[0-9]{4}-[0-9]{4}$");
        private static readonly Regex LongFormNoLineRegex = new(@"^[0-9]{4}$");

        public static string Trim(string season) 
        {
            if (season != null) 
            {
                if (CorrectRegex.IsMatch(season)) 
                {
                    return season;
                }
                else if (LongFormRegex.IsMatch(season))
                {
                    return season.Replace("-", "");
                }
                else if (LongFormNoLineRegex.IsMatch(season))
                {
                    var startYear = Convert.ToInt32(season);
                    return $"{startYear}{startYear + 1}";
                }

                return null;
            }

            return null;
        }

        public static string ToLongForm(string season) 
        {
            if (CorrectRegex.IsMatch(season)) 
            {
                season = season.Insert(4, "-");
                return season;
            }
            return null;
        }
    }
}
