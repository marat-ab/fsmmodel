using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    public class TransitionAlreadyExistsInOutMapException : Exception
    {
        public TransitionAlreadyExistsInOutMapException(State state, Signal signal)
            : base(message: $"Transition with head ({state}, {signal}) already exists in out map.") { }
    }
}
