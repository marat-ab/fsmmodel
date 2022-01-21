using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownSignalException : Exception
    {
        public UnknownSignalException(Signal signal)
            : base(message: $"Unknown signal: {signal} error occured.") { }
    }
}
