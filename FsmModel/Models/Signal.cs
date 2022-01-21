using System;

namespace FsmModel.Models
{
    public class Signal : IEquatable<Signal>
    {
        public string Value { get; set; }

        public Signal(string value) =>
            Value = value;

        public override bool Equals(object? obj) =>
            this.Equals(obj as Signal);

        public bool Equals(Signal? other)
        {
            if (other is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            return Value == other.Value;
        }

        public override int GetHashCode() =>
            Value.GetHashCode();

        public static bool operator ==(Signal lhs, Signal rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Signal lhs, Signal rhs)
            => !(lhs == rhs);

        public override string ToString() =>
            Value;
    }
}
