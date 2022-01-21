using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    class UnknownStateSignalPairInStateMap : Exception
    {
        public UnknownStateSignalPairInStateMap(State currentState, Signal signal)
            : base(message: $"Pair ({currentState}, {signal}) is absent in state map.") { }
    }
}
