using FsmModel.Models;
using System;

namespace FsmModel.Dfa.Exceptions
{
    class UnknownStateSignalPairInStateMap : Exception
    {
        public UnknownStateSignalPairInStateMap(State currentState, InSignal signal)
            : base(message: $"Pair ({currentState}, {signal}) is absent in state map.") { }
    }
}
