using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownActionException : Exception
    {
        public UnknownActionException(Signal outSignal)
            : base(message: $"Unknown action for out signal: {outSignal} error occured.") { }
    }
}
