using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    public class UnknownActionException : Exception
    {
        public UnknownActionException(OutSignal outSignal)
            : base(message: $"Unknown action for out signal: {outSignal} error occured.") { }
    }
}
