using FsmModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Dfa
{
    public partial class DfaModel
    {
        public Dictionary<ValueTuple<State, Signal>, State> StateMap
        {
            get => _stateMap.ToDictionary(k => k.Key, v => v.Value);
        }

        public Dictionary<ValueTuple<State, Signal>, Signal> OutMap
        {
            get => _outSignalMap.ToDictionary(k => k.Key, v => v.Value);
        }

        public List<State> FinalStates { get => _finalStates.ToList(); }
    }
}
