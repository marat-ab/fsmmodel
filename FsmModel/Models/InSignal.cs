using System;

namespace FsmModel.Models
{
    public class InSignal : IEquatable<InSignal>
    {
        public string Value { get; set; }

        public InSignal(string value) =>
            Value = value;

        public override bool Equals(object? obj) =>
            this.Equals(obj as InSignal);

        public bool Equals(InSignal? other)
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

        public static bool operator ==(InSignal lhs, InSignal rhs)
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

        public static bool operator !=(InSignal lhs, InSignal rhs)
            => !(lhs == rhs);

        public override string ToString() =>
            Value;
    }
}
