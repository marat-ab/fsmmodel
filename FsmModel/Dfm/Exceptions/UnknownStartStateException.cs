using System;

namespace FsmModel.Dfm.Exceptions
{
    public class UnknownStartStateException : Exception
    {
        public UnknownStartStateException(string state)
            : base(message: $"Unknown start state: {state} error.") { }
    }
}
