using FsmModel.Dfa;
using FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions;
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

        private static Dictionary<ValueTuple<State, InSignal>, State> BuildStateMap(TransitionTable model)
        {
            if (model.StateMap is null)
                throw new StateMapException("State map is null");

            var stateMap = new Dictionary<ValueTuple<State, InSignal>, State>();

            List<InSignal> inSignals = model.StateMap.First()
                                        .TakeLast(model.StateMap.First().Count - 1)
                                        .Select(v => new InSignal(v))
                                        .ToList();

            foreach (var row in model.StateMap.Skip(1))
            {
                var state = row[0];
                foreach (var s in row.Skip(1).Select((v, i) => (v, i)))
                {
                    stateMap.Add((new(state), inSignals[s.i]), new(s.v));
                }
            }

            return stateMap;
        }

        private static Dictionary<ValueTuple<State, InSignal>, OutSignal> BuildOutMap(TransitionTable model)
        {
            if (model.OutMap is null)
                throw new OutMapException("Out map is null");
            
            var outMap = new Dictionary<ValueTuple<State, InSignal>, OutSignal>();

            List<InSignal> inSignals = model.OutMap.First()
                                        .TakeLast(model.OutMap.First().Count - 1)
                                        .Select(v => new InSignal(v))
                                        .ToList();

            foreach (var row in model.OutMap.Skip(1))
            {
                var state = row[0];
                foreach (var s in row.Skip(1).Select((v, i) => (v, i)))
                {
                    outMap.Add((new(state), inSignals[s.i]), new(s.v));
                }
            }

            return outMap;
        }

        private static State GetInitialState(TransitionTable model) =>
            model.InitialState switch
            {
                null => throw new InitialStateException("Initial state is null"),
                _ => new(model.InitialState)
            };

        private static List<State> GetFinishStates(TransitionTable model) =>
            model.FinishStates switch
            {
                null => throw new FinishStatesException("Finish states is null"),
                _ => model.FinishStates.Select(v => new State(v)).ToList()
            };            

        private static bool IsNeedJournal(TransitionTable model) =>
            model.IsNeedJournal;
    }
}
