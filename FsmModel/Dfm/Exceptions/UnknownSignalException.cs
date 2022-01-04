using System;

namespace FsmModel.Dfm.Exceptions
{
    public class UnknownSignalException : Exception
    {
        public UnknownSignalException(string signal)
            : base(message: $"Unknown signal: {signal} error occured.") { }
    }
}
