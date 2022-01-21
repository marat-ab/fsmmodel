using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownInitialStateException : Exception
    {
        public UnknownInitialStateException(State state)
            : base(message: $"Unknown initial state: {state} error.") { }
    }
}
