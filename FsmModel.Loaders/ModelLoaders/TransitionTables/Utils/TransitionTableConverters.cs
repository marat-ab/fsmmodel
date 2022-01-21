using FsmModel.Dfa;
using FsmModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Utils
{
    public static class TransitionTableConverters
    {
        public static DfaModel? ToDfaModel(TransitionTable model)
        {
            var stateMap = BuildStateMap(model);
            //var outMap = BuildOutMap(model);
            //var initialState = GetInitialState(model);
            //var finishStates = GetFinishStates(model);
            //var isNeedJournal = isNeedJournal(model);

            //   var dfaModel = DfaModel(
            //Dictionary<ValueTuple<string, string>, string> stateMap,
            //Dictionary<ValueTuple<string, string>, string> outMap,
            //string initialState,
            //List<string> finishStates,
            //Dictionary<string, Action> actions,
            //bool isNeedJournal = false,
            //bool isActionsDeactivated = true)
            return null;
        }

        public static Dictionary<ValueTuple<State, Signal>, State> BuildStateMap(TransitionTable table)
        {
            var stateMap = new Dictionary<ValueTuple<State, Signal>, State>();

            List<Signal> inSignals = table.StateMap.First()
                                        .TakeLast(table.StateMap.Count - 1)
                                        .Select(v => new Signal(v))
                                        .ToList();
            
            foreach(var row in table.StateMap.Skip(1))
            {
                var state = row[0];
                foreach(var s in row.Skip(1).Select((v, i) => (v, i)))
                {
                    stateMap.Add((new(state), inSignals[s.i]), new(s.v));
                }
            }

            return stateMap;
        }
    }
}
