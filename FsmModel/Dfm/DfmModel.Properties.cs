using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Dfm
{
    public partial class DfmModel : IDfmModel
    {
        public Dictionary<ValueTuple<string, string>, string> StateMap
        {
            get => _stateMap.ToDictionary(k => k.Key, v => v.Value);
        }

        public Dictionary<ValueTuple<string, string>, string> OutMap
        {
            get => _outMap.ToDictionary(k => k.Key, v => v.Value);
        }

        public string StartState { get => _startState; }

        public List<string> FinishStates { get => _finishStates.ToList(); }

        public bool IsNeedJournal { get => _isNeedJournal; }

        public bool IsDeactivateOutMsgs { get => _isDeactivateOutMsgs; set => _isDeactivateOutMsgs = value; }
    }
}
