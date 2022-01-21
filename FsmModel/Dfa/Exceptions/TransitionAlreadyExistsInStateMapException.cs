using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    public class TransitionAlreadyExistsInStateMapException : Exception
    {
        public TransitionAlreadyExistsInStateMapException(State state, InSignal signal)
            : base(message: $"Transition with head ({state}, {signal}) already exists in state map.") { }
    }
}
