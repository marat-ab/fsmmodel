using FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables
{
    public partial class TransitionTableLoader
    {
        private readonly List<string> _states = new();

        private void ValidateTableModel(TransitionTable? model)
        {
            if (model is null)
                throw new TransitionTableModelIsNullException();

            CheckStates(model);
            CheckInitialState(model);
            CheckFinishStates(model);
            CheckOutMap(model);
        }

        private void CheckStates(TransitionTable model)
        {
            if (model.StateMap is null)
                throw new StateMapException("State map is null");

            if (model.StateMap.Count <= 2)
                throw new StateMapException("Count of lines in state map must be high then 2");

            // Check that all rows has same cols count
            var numCols = model.StateMap.First().Count;
            foreach (var row in model.StateMap)
                if (row.Count != numCols)
                    throw new StateMapException("State map has different count of elements in rows");

            // Check states
            foreach (var row in model.StateMap.Skip(1))
                _states.Add(row.First());

            if (_states.Count != _states.Distinct().Count())
                throw new StateMapException("State map has duplicates among the first elements of the table");

            foreach (var row in model.StateMap.Skip(1))
                if (row.Except(_states).Any())
                    throw new StateMapException("Unknown state in state map");

            // Check input signals
            var inputSignals = model.StateMap.First().Skip(1).ToList();
            if (inputSignals.Count != inputSignals.Distinct().Count())
                throw new StateMapException("Input signals has duplicates");
        }

        private void CheckInitialState(TransitionTable model)
        {
            if (model.InitialState is null)
                throw new InitialStateException("Initial state is null");

            if (!_states.Contains(model.InitialState))
                throw new InitialStateException("Unknown initial state, check StateMap");
        }

        private void CheckFinishStates(TransitionTable model)
        {
            if (model.FinishStates is null)
                throw new FinishStatesException("Finish states is null");

            foreach (var s in model.FinishStates)
                if (!_states.Contains(s))
                    throw new FinishStatesException($"Unknown finish state {s}");
        }

        private void CheckOutMap(TransitionTable model)
        {
            if (model.OutMap is null)
                throw new OutMapException("Out map is null");

            if (model.OutMap.Count <= 2)
                throw new OutMapException("Count of lines in out map must be high then 2");

            // Check that all rows has same cols count
            var numCols = model.OutMap.First().Count;
            foreach (var row in model.OutMap)
                if (row.Count != numCols)
                    throw new OutMapException("Out map has different count of elements in rows");

            // Check states
            var outMapStates = new List<string>();
            foreach (var row in model.OutMap.Skip(1))
                outMapStates.Add(row.First());

            if (_states.Except(outMapStates).Any() || outMapStates.Except(_states).Any())
                throw new OutMapException("State map and Out map is different");

            // Check input signals
            var inputSignals = model.OutMap.First().Skip(1).ToList();
            if (inputSignals.Count != inputSignals.Distinct().Count())
                throw new StateMapException("Input signals has duplicates in out map");
        }
    }
}
