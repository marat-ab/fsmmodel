using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownStateException : Exception
    {
        public UnknownStateException(State state)
            : base(message: $"Unknown state: {state} error.") { }
    }
}
