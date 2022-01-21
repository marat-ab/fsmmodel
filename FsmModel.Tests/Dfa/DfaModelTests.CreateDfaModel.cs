using FluentAssertions;
using FsmModel.Dfa;
using FsmModel.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FsmModel.Tests.Dfa
{
    [TestFixture]
    partial class DfaModelTests
    {
        [Test]
        public void CreateEmptyDfaModel_NormallyCreated()
        {
            // Given
            var expectedStateMap = new Dictionary<ValueTuple<State, InSignal>, State>();
            var expectedOutMap = new Dictionary<ValueTuple<State, InSignal>, OutSignal>();
            var expectedStartState = new State(string.Empty);
            var expectedFinishStates = new List<State>();

            // When
            var dfaEmpty = new DfaModel();

            // Then
            dfaEmpty.StateMap.Should().BeEquivalentTo(expectedStateMap);
            dfaEmpty.OutMap.Should().BeEquivalentTo(expectedOutMap);
            dfaEmpty.FinishStates.Should().BeEquivalentTo(expectedFinishStates);

            dfaEmpty.GetInitialState().Should().Be(expectedStartState);
            dfaEmpty.IsNeedJournal().Should().BeFalse();
            dfaEmpty.IsActionsDeactivated().Should().BeTrue();

            dfaEmpty.IsFinal().Should().BeFalse();
            dfaEmpty.GetJournal().IsEmpty().Should().BeTrue();
        }

        [Test]
        public void CreateDfaByCtorWithAllArgs_NormallyCreated()
        {
            // Given
            var q0 = new State("q0");
            var q1 = new State("q1");

            var s0 = new InSignal("0");
            var s1 = new InSignal("1");

            var r0 = new OutSignal("OFF");
            var r1 = new OutSignal("ON");

            var stateMap = new Dictionary<ValueTuple<State, InSignal>, State>()
            {
                [(q0, s0)] = q0,
                [(q0, s1)] = q1,
                [(q1, s0)] = q0,
                [(q1, s1)] = q1
            };
            var outMap = new Dictionary<ValueTuple<State, InSignal>, OutSignal>()
            {
                [(q0, s0)] = r0,
                [(q0, s1)] = r1,
                [(q1, s0)] = r0,
                [(q1, s1)] = r1
            };
            var initialState = q0;
            var finishStates = new List<State>() { q0, q1 };
            var actions = new Dictionary<OutSignal, Action>();
            var isNeedJournal = true;
            var isActionDeactivated = false;

            // When
            var dfa = new DfaModel(stateMap,
                outMap,
                initialState,
                finishStates,
                actions,
                isNeedJournal,
                isActionDeactivated);

            // Then
            dfa.StateMap.Should().BeEquivalentTo(stateMap);
            dfa.OutMap.Should().BeEquivalentTo(outMap);
            dfa.FinishStates.Should().BeEquivalentTo(finishStates);

            dfa.GetInitialState().Should().Be(initialState);
            dfa.IsNeedJournal().Should().BeTrue();
            dfa.IsActionsDeactivated().Should().BeFalse();

            dfa.GetCurrentState().Should().Be(initialState);

            dfa.IsFinal().Should().BeTrue();
            dfa.GetJournal().IsEmpty().Should().BeTrue();
        }

        [Test]
        public void CreateDfaByFluentApi_NormallyCreated()
        {
            // Given
            var q0 = new State("q0");
            var q1 = new State("q1");

            var s0 = new InSignal("0");
            var s1 = new InSignal("1");

            var r0 = new OutSignal("OFF");
            var r1 = new OutSignal("ON");

            var stateMap = new Dictionary<ValueTuple<State, InSignal>, State>()
            {
                [(q0, s0)] = q0,
                [(q0, s1)] = q1,
                [(q1, s0)] = q0,
                [(q1, s1)] = q1
            };
            var outMap = new Dictionary<ValueTuple<State, InSignal>, OutSignal>()
            {
                [(q0, s0)] = r0,
                [(q0, s1)] = r1,
                [(q1, s0)] = r0,
                [(q1, s1)] = r1
            };
            var initialState = q0;
            var finishStates = new List<State>() { q0, q1 };
            var actions = new Dictionary<OutSignal, Action>();
            var isNeedJournal = true;
            var isActionDeactivated = false;

            // When
            var dfa = (DfaModel)(new DfaModel())
                .AddTrasition(q0, q0, s0, true, r0)
                .AddTrasition(q0, q1, s1, true, r1)
                .AddTrasition(q1, q1, s1, true, r1)
                .AddTrasition(q1, q0, s0, true, r0)
                .SetInitialState(q0)
                .SetIsNeedJournal(isNeedJournal)
                .SetIsNeedActionsDeactivate(isActionDeactivated);

            // Then
            dfa.StateMap.Should().BeEquivalentTo(stateMap);
            dfa.OutMap.Should().BeEquivalentTo(outMap);
            dfa.FinishStates.Should().BeEquivalentTo(finishStates);

            dfa.GetInitialState().Should().Be(initialState);
            dfa.IsNeedJournal().Should().BeTrue();
            dfa.IsActionsDeactivated().Should().BeFalse();

            dfa.GetCurrentState().Should().Be(initialState);

            dfa.IsFinal().Should().BeTrue();
            dfa.GetJournal().IsEmpty().Should().BeTrue();
        }
    }
}
