using System;
using System.Linq;
using System.Text.RegularExpressions;
using VietBuddy.Shared;

namespace VietBuddy.Components
{
    public static class Utilities
    {
        public static string Highlight(this string sentence, string highlight)
        {
            highlight = highlight.RemovePunctuation();

            var matches = Regex.Matches(sentence, highlight, RegexOptions.IgnoreCase);
            if (matches.Count > 0)
            {
                foreach (var match in matches)
                    sentence = sentence.Replace(match.ToString(), $"<mark>{match}</mark>");
                return sentence;
            }

            var syllables = sentence.RemovePunctuation().Split(" ").ToList().Distinct();
            foreach (var syllable in syllables)
                if (Regex.IsMatch(highlight, syllable, RegexOptions.IgnoreCase))
                    sentence = sentence.Replace(syllable, $"<mark>{syllable}</mark>");
            
            return sentence;
        }
    }
}
