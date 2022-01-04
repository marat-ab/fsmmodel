﻿using FsmModel.Dfm.Exceptions;
using FsmModel.Journal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Dfm
{
    public partial class DfmModel : IDfmModel
    {
        readonly private Dictionary<ValueTuple<string, string>, string> _stateMap = new();
        readonly private Dictionary<ValueTuple<string, string>, string> _outMap = new();
        private string _startState = string.Empty;
        readonly private List<string> _finishStates = new();
        private bool _isNeedJournal = false;
        private bool _isActionsDeactivated = true;

        private readonly Dictionary<string, Action> _actions = new();

        private IFsmJournal _journal = new FsmJournal();
        private string _currentState = string.Empty;

        readonly private List<string> _signals = new();
        readonly private List<string> _states = new();

        public DfmModel()
        {
        }

        public DfmModel(
            Dictionary<ValueTuple<string, string>, string> stateMap,
            Dictionary<ValueTuple<string, string>, string> outMap,
            string startState,
            List<string> finishStates,
            Dictionary<string, Action> actions,
            bool isNeedJournal = false,
            bool isActionsDeactivated = true)
        {
            _stateMap = stateMap.ToDictionary(k => k.Key, v => v.Value);
            _outMap = outMap.ToDictionary(k => k.Key, v => v.Value);
            _startState = startState;
            _finishStates = finishStates;
            _actions = actions.ToDictionary(k => k.Key, v => v.Value);
            _isNeedJournal = isNeedJournal;
            _isActionsDeactivated = isActionsDeactivated;

            FsmStartTuning();
        }

        // IDfmModel
        public IDfmModel Reset()
        {
            _journal = new FsmJournal();

            _currentState = _startState;

            return this;
        }

        public IDfmModel Act(string signal)
        {
            // Checks
            if (!_signals.Contains(signal))
                throw new UnknownSignalException(signal);

            if (!_stateMap.ContainsKey((_currentState, signal)))
                throw new UnknownStateSignalPairInStateMap(_currentState, signal);

            if (!_isActionsDeactivated && !_actions.ContainsKey(_outMap[(_currentState, signal)]))
                throw new UnknownActionException(_outMap[(_currentState, signal)]);

            // Processing
            var oldState = _currentState;
            var outMsg = _outMap[(_currentState, signal)];

            _currentState = _stateMap[(_currentState, signal)];

            if (!_isActionsDeactivated)
                _actions[outMsg]();

            if (_isNeedJournal)
                _journal.AddEvent(signal, oldState, outMsg);

            return this;
        }

        public IDfmModel AddTrasition(
            string fromState,
            string toState,
            string bySignal,
            bool isFinished,
            string outMsg,
            Action action)
        {
            // Checks
            if (fromState is null || toState is null || bySignal is null || outMsg is null)
                throw new ArgumentNullException($"Args: fromState: {fromState}, toState: {toState}, " +
                    $"bySignal: {bySignal}, outMsg: {outMsg}");

            if (_stateMap.ContainsKey((fromState, bySignal)))
                throw new TransitionAlreadyExistsInStateMapException(fromState, bySignal);

            if (_outMap.ContainsKey((fromState, bySignal)))
                throw new TransitionAlreadyExistsInOutMapException(fromState, bySignal);

            // Processing
            if (!_states.Contains(fromState))
                _states.Add(fromState);

            if (!_states.Contains(toState))
                _states.Add(toState);

            if (!_signals.Contains(bySignal))
                _signals.Add(bySignal);

            _stateMap.Add((fromState, bySignal), toState);

            if (isFinished && !_finishStates.Contains(toState))
                _finishStates.Add(toState);

            _outMap.Add((fromState, bySignal), outMsg);

            if (!_actions.ContainsKey(outMsg))
                _actions.Add(outMsg, action);

            return this;
        }

        public IDfmModel SetStartState(string startState)
        {
            if (!_states.Contains(startState))
                throw new UnknownStartStateException(startState);

            _startState = startState;

            if (_currentState == "")
                _currentState = _startState;

            return this;
        }

        public string GetStartState() =>
            _startState;

        public IDfmModel SetIsNeedJournal(bool isNeedJournal)
        {
            _isNeedJournal = isNeedJournal;

            return this;
        }

        public bool IsNeedJournal() =>
            _isNeedJournal;

        public IDfmModel SetIsNeedActionsDeactivate(bool isNeedActionsDeactivate)
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
            _outMap.Clear();
            _startState = string.Empty;
            _finishStates.Clear();
            _isNeedJournal = false;
            _isActionsDeactivated = true;

            _actions.Clear();

            _journal.Clear();
            _currentState = string.Empty;

            _signals.Clear();
            _states.Clear();
        }

        public IFsmJournal GetJournal() =>
            (IFsmJournal)((FsmJournal)_journal).Clone();

        public bool IsFinished() =>
            _finishStates.Contains(_currentState);

        // Private
        private void FsmStartTuning()
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

            foreach (var trans in _outMap)
            {
                if (!_states.Contains(trans.Key.Item1))
                    throw new UnknownStateException(trans.Key.Item1);

                if (!_signals.Contains(trans.Key.Item2))
                    throw new UnknownSignalException(trans.Key.Item2);
            }

            if (!_states.Contains(_startState))
                throw new UnknownStartStateException(_startState);

            _currentState = _startState;
        }

    }
}
