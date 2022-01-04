using FsmModel.Dfa.Exceptions;
using FsmModel.Journal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Dfa
{
    public partial class DfaModel : IDfaModel
    {
        readonly private Dictionary<ValueTuple<string, string>, string> _stateMap = new();
        readonly private Dictionary<ValueTuple<string, string>, string> _outSignalMap = new();
        private string _initialState = string.Empty;
        readonly private List<string> _finalStates = new();
        private bool _isNeedJournal = false;
        private bool _isActionsDeactivated = true;

        private readonly Dictionary<string, Action> _actions = new();

        private IFsmJournal _journal = new FsmJournal();
        private string _currentState = string.Empty;
        private string _outSignal = string.Empty;

        readonly private List<string> _signals = new();
        readonly private List<string> _states = new();

        public DfaModel()
        {
        }

        public DfaModel(
            Dictionary<ValueTuple<string, string>, string> stateMap,
            Dictionary<ValueTuple<string, string>, string> outMap,
            string initialState,
            List<string> finishStates,
            Dictionary<string, Action> actions,
            bool isNeedJournal = false,
            bool isActionsDeactivated = true)
        {
            _stateMap = stateMap.ToDictionary(k => k.Key, v => v.Value);
            _outSignalMap = outMap.ToDictionary(k => k.Key, v => v.Value);
            _initialState = initialState;
            _finalStates = finishStates;
            _actions = actions.ToDictionary(k => k.Key, v => v.Value);
            _isNeedJournal = isNeedJournal;
            _isActionsDeactivated = isActionsDeactivated;

            StartTuning();
        }

        // IDfmModel
        public IDfaModel Reset()
        {
            _journal.Clear();

            _currentState = _initialState;
            _outSignal = string.Empty;

            return this;
        }

        public IDfaModel Act(string signal)
        {
            // Checks
            if (!_signals.Contains(signal))
                throw new UnknownSignalException(signal);

            if (!_stateMap.ContainsKey((_currentState, signal)))
                throw new UnknownStateSignalPairInStateMap(_currentState, signal);

            if (!_isActionsDeactivated && !_actions.ContainsKey(_outSignalMap[(_currentState, signal)]))
                throw new UnknownActionException(_outSignalMap[(_currentState, signal)]);

            // Processing
            var oldState = _currentState;
            var outSignal = _outSignalMap[(_currentState, signal)];

            _currentState = _stateMap[(_currentState, signal)];
            _outSignal = outSignal;

            if (!_isActionsDeactivated)
                _actions[outSignal]();

            if (_isNeedJournal)
                _journal.AddEvent(signal, oldState, outSignal);

            return this;
        }

        public IDfaModel AddTrasition(
            string fromState,
            string toState,
            string bySignal,
            bool isFinished,
            string outSignal,
            Action? action = null)
        {
            // Checks
            if (fromState is null || toState is null || bySignal is null || outSignal is null)
                throw new ArgumentNullException($"Args: fromState: {fromState}, toState: {toState}, " +
                    $"bySignal: {bySignal}, outSignal: {outSignal}");

            if (_stateMap.ContainsKey((fromState, bySignal)))
                throw new TransitionAlreadyExistsInStateMapException(fromState, bySignal);

            if (_outSignalMap.ContainsKey((fromState, bySignal)))
                throw new TransitionAlreadyExistsInOutMapException(fromState, bySignal);

            // Processing
            if (!_states.Contains(fromState))
                _states.Add(fromState);

            if (!_states.Contains(toState))
                _states.Add(toState);

            if (!_signals.Contains(bySignal))
                _signals.Add(bySignal);

            _stateMap.Add((fromState, bySignal), toState);

            if (isFinished && !_finalStates.Contains(toState))
                _finalStates.Add(toState);

            _outSignalMap.Add((fromState, bySignal), outSignal);

            if (!_actions.ContainsKey(outSignal))
                _actions.Add(outSignal, action is null ? () => { } : action);

            return this;
        }

        public string GetOutSignal() =>
            _outSignal;

        public IDfaModel SetInitialState(string initialState)
        {
            if (!_states.Contains(initialState))
                throw new UnknownInitialStateException(initialState);

            _initialState = initialState;

            if (_currentState == "")
                _currentState = _initialState;

            return this;
        }

        public string GetInitialState() =>
            _initialState;

        public IDfaModel SetIsNeedJournal(bool isNeedJournal)
        {
            _isNeedJournal = isNeedJournal;

            return this;
        }

        public bool IsNeedJournal() =>
            _isNeedJournal;

        public IDfaModel SetIsNeedActionsDeactivate(bool isNeedActionsDeactivate)
        {
            _isActionsDeactivated = isNeedActionsDeactivate;

            return this;
        }

        public bool IsActionsDeactivated() =>
            _isActionsDeactivated;

        public string GetCurrentState() =>
            _currentState;

        public void Clear()
        {
            _stateMap.Clear();
            _outSignalMap.Clear();
            _initialState = string.Empty;
            _finalStates.Clear();
            _isNeedJournal = false;
            _isActionsDeactivated = true;

            _actions.Clear();

            _journal.Clear();
            _currentState = string.Empty;
            _outSignal = string.Empty;

            _signals.Clear();
            _states.Clear();
        }

        public IFsmJournal GetJournal() =>
            (IFsmJournal)((FsmJournal)_journal).Clone();

        public bool IsFinal() =>
            _finalStates.Contains(_currentState);

        // Private
        private void StartTuning()
        {
            foreach (var trans in _stateMap)
            {
                if (!_states.Contains(trans.Key.Item1))
                    _states.Add(trans.Key.Item1);

                if (!_states.Contains(trans.Value))
                    _states.Add(trans.Value);

                if (!_signals.Contains(trans.Key.Item2))
                    _signals.Add(trans.Key.Item2);
            }

            foreach (var trans in _outSignalMap)
            {
                if (!_states.Contains(trans.Key.Item1))
                    throw new UnknownStateException(trans.Key.Item1);

                if (!_signals.Contains(trans.Key.Item2))
                    throw new UnknownSignalException(trans.Key.Item2);
            }

            if (!_states.Contains(_initialState))
                throw new UnknownInitialStateException(_initialState);

            _currentState = _initialState;
            _outSignal = string.Empty;
        }

    }
}
