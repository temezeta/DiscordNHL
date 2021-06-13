using System;
using System.Text.RegularExpressions;

namespace DiscordNHL.Helpers
{
    public static class SeasonYearHelper
    {
        public static readonly Regex LongFormRegex = new(@"^[0-9]{4}-[0-9]{4}$");
        public static readonly Regex LongFormNoLineRegex = new(@"^[0-9]{4}$");

        public static string Trim(string season) 
        {
            if (season != null) 
            {
                if (LongFormRegex.IsMatch(season))
                {
                    return season.Replace("-", "");
                }
                else if (LongFormNoLineRegex.IsMatch(season)) 
                {
                    var startYear = Convert.ToInt32(season);
                    return $"{startYear}{startYear + 1}";
                }
            }

            return season;
        }
    }
}
