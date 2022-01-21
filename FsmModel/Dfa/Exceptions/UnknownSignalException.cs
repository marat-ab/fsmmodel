using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownSignalException : Exception
    {
        public UnknownSignalException(InSignal signal)
            : base(message: $"Unknown signal: {signal} error occured.") { }
    }
}
