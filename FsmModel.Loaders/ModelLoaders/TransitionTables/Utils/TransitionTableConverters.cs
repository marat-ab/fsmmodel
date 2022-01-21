using FsmModel.Dfa;
using FsmModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Utils
{
    public static class TransitionTableConverters
    {
        public static DfaModel? ToDfaModel(TransitionTable model)
        {
            var stateMap = BuildStateMap(model);
            var outMap = BuildOutMap(model);
            var initialState = GetInitialState(model);
            var finishStates = GetFinishStates(model);
            var isNeedJournal = IsNeedJournal(model);

            var dfaModel = new DfaModel(stateMap,
                            outMap,
                            initialState,
                            finishStates,
                            new(),
                            isNeedJournal);

            return dfaModel;
        }

        private static Dictionary<ValueTuple<State, InSignal>, State> BuildStateMap(TransitionTable table)
        {
            var stateMap = new Dictionary<ValueTuple<State, InSignal>, State>();

            List<InSignal> inSignals = table.StateMap.First()
                                        .TakeLast(table.StateMap.Count - 1)
                                        .Select(v => new InSignal(v))
                                        .ToList();

            foreach (var row in table.StateMap.Skip(1))
            {
                var state = row[0];
                foreach (var s in row.Skip(1).Select((v, i) => (v, i)))
                {
                    stateMap.Add((new(state), inSignals[s.i]), new(s.v));
                }
            }

            return stateMap;
        }

        private static Dictionary<ValueTuple<State, InSignal>, OutSignal> BuildOutMap(TransitionTable table)
        {
            var outMap = new Dictionary<ValueTuple<State, InSignal>, OutSignal>();

            List<InSignal> inSignals = table.OutMap.First()
                                        .TakeLast(table.OutMap.Count - 1)
                                        .Select(v => new InSignal(v))
                                        .ToList();

            foreach (var row in table.OutMap.Skip(1))
            {
                var state = row[0];
                foreach (var s in row.Skip(1).Select((v, i) => (v, i)))
                {
                    outMap.Add((new(state), inSignals[s.i]), new(s.v));
                }
            }

            return outMap;
        }

        private static State GetInitialState(TransitionTable table) =>
            new(table.InitialState);

        private static List<State> GetFinishStates(TransitionTable table) =>
            table.FinishStates.Select(v => new State(v)).ToList();

        private static bool IsNeedJournal(TransitionTable table) =>
            table.IsNeedJournal;

    }
}
