using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Dfa
{
    public partial class DfaModel : IDfaModel
    {
        public Dictionary<ValueTuple<string, string>, string> StateMap
        {
            get => _stateMap.ToDictionary(k => k.Key, v => v.Value);
        }

        public Dictionary<ValueTuple<string, string>, string> OutMap
        {
            get => _outSignalMap.ToDictionary(k => k.Key, v => v.Value);
        }

        public List<string> FinalStates { get => _finalStates.ToList(); }
    }
}
