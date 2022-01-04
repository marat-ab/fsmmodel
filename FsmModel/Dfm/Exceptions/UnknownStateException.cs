using System;

namespace FsmModel.Dfm.Exceptions
{
    public class UnknownStateException : Exception
    {
        public UnknownStateException(string state)
            : base(message: $"Unknown state: {state} error.") { }
    }
}
