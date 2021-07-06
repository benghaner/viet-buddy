using System;
using System.Text.RegularExpressions;

namespace VietBuddy.Web.Shared
{
    public static class Utilities
    {
        public static string Highlight(this string sentence, string highlight)
        {
            var matches = Regex.Matches(sentence, highlight, RegexOptions.IgnoreCase);

            foreach (var match in matches)
                sentence = sentence.Replace(match.ToString(), $"<mark>{match}</mark>");

            return sentence;
        }
    }
}
