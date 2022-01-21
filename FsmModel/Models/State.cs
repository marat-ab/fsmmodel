using System;

namespace FsmModel.Models
{
    public class State: IEquatable<State>
    {
        public string Value { get; set; }

        public State(string value) =>
            Value = value;

        public override bool Equals(object? obj) => 
            this.Equals(obj as State);

        public bool Equals(State? other)
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

        public static bool operator ==(State lhs, State rhs)
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

        public static bool operator !=(State lhs, State rhs)
            => !(lhs == rhs);

        public override string ToString() =>
            Value;
    }
}
