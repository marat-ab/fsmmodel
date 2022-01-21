using FsmModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Dfa
{
    public partial class DfaModel
    {
        public Dictionary<ValueTuple<State, InSignal>, State> StateMap
        {
            get => _stateMap.ToDictionary(k => k.Key, v => v.Value);
        }

        public Dictionary<ValueTuple<State, InSignal>, OutSignal> OutMap
        {
            get => _outSignalMap.ToDictionary(k => k.Key, v => v.Value);
        }

        public List<State> FinishStates
        {
            get => _finalStates.ToList();
        }
    }
}
