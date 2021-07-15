using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace VietBuddy.Shared
{
    public interface IJsonClonable {}
    
    public static class JsonExtensions
    {
        public static T Clone<T>(this T original) where T : IJsonClonable
        {
            string json = JsonSerializer.Serialize<T>(original);
            return JsonSerializer.Deserialize<T>(json);
        }
    }

    public class Text : IEquatable<Text>
    {
        public string Value { get; set; }

        public Text() {}
        public Text(string value) => this.Value = value;

        public bool Equals(Text other)
        {
            if (other is null)
                return false;
            return this.Value == other.Value;
        }

        public override bool Equals(object obj) => Equals(obj as Text);
        public override int GetHashCode() => this.Value.GetHashCode();
    }

    public static class TextExtensions
    {
        public static List<string> ToListString(this IList<Text> list)
        {
            return list
                .Where(e => !String.IsNullOrEmpty(e.Value))
                .Select(e => e.Value)
                .ToList();
        }
    }

    public static class StringExtensions
    {
        public static List<Text> ToListText(this List<string> list)
        {
            return list
                .Where(e => !String.IsNullOrEmpty(e))
                .Select(e => new Text(e))
                .ToList();
        }

        public static string RemovePunctuation(this string input)
        {
            return new string(input.Where(c => !char.IsPunctuation(c)).ToArray());
        }
    }

    public static class RegexPatterns
    {
        public static string WholeWord(string word) => @"(?<!\w)" + word + @"(?!\w)";
    }
}
