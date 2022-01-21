using FsmModel.Dfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Utils
{
    static class TransitionTableConverters
    {
        public static DfaModel ToDfaModel(TransitionTable model)
        {
            var stateMap = BuildStateMap(model);
            var outMap = BuildOutMap(model);
            var initialState = GetInitialState(model);
            var finishStates = GetFinishStates(model);
            var isNeedJournal = isNeedJournal(model);

          //   var dfaModel = DfaModel(
          //Dictionary<ValueTuple<string, string>, string> stateMap,
          //Dictionary<ValueTuple<string, string>, string> outMap,
          //string initialState,
          //List<string> finishStates,
          //Dictionary<string, Action> actions,
          //bool isNeedJournal = false,
          //bool isActionsDeactivated = true)
        }

        public static Dictionary<ValueTuple<string, string>, string> BuildStateMap(TransitionTable table)
        {

        }
    }
}
