using System;

namespace FsmModel.Dfm.Exceptions
{
    public class UnknownActionException : Exception
    {
        public UnknownActionException(string outSignal)
            : base(message: $"Unknown action for out signal: {outSignal} error occured.") { }
    }
}
