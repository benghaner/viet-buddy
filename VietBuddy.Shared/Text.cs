using System;

namespace VietBuddy.Shared
{
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
}
