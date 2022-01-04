using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownStateException : Exception
    {
        public UnknownStateException(string state)
            : base(message: $"Unknown state: {state} error.") { }
    }
}
