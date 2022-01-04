using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownInitialStateException : Exception
    {
        public UnknownInitialStateException(string state)
            : base(message: $"Unknown initial state: {state} error.") { }
    }
}
