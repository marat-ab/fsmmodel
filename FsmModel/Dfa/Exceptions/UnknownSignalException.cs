using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownSignalException : Exception
    {
        public UnknownSignalException(string signal)
            : base(message: $"Unknown signal: {signal} error occured.") { }
    }
}
