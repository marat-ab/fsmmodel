using System;

namespace FsmModel.Dfa.Exceptions
{
    public class TransitionAlreadyExistsInOutMapException : Exception
    {
        public TransitionAlreadyExistsInOutMapException(string state, string signal)
            : base(message: $"Transition with head ({state}, {signal}) already exists in out map.") { }
    }
}
