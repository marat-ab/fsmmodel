using FluentAssertions;
using FsmModel.Dfa;
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
            var emptyStateMap = new Dictionary<ValueTuple<string, string>, string>();
            var emptyOutMap = new Dictionary<ValueTuple<string, string>, string>();
            var unsettedStartState = "";
            var emptyFinishStates = new List<string>();

            // When
            var dfaEmpty = new DfaModel();

            // Then
            dfaEmpty.StateMap.Should().BeEquivalentTo(emptyStateMap);
            dfaEmpty.OutMap.Should().BeEquivalentTo(emptyOutMap);
            dfaEmpty.FinalStates.Should().BeEquivalentTo(emptyFinishStates);

            dfaEmpty.GetInitialState().Should().Be(unsettedStartState);
            dfaEmpty.IsNeedJournal().Should().BeFalse();
            dfaEmpty.IsActionsDeactivated().Should().BeTrue();

            dfaEmpty.IsFinal().Should().BeFalse();
            dfaEmpty.GetJournal().IsEmpty().Should().BeTrue();
        }

        [Test]
        public void CreateDfaByCtorWithAllArgs_NormallyCreated()
        {
            // Given
            var stateMap = new Dictionary<ValueTuple<string, string>, string>()
            {
                [("a", "0")] = "a",
                [("a", "1")] = "b",
                [("b", "0")] = "a",
                [("b", "1")] = "b"
            };
            var outMap = new Dictionary<ValueTuple<string, string>, string>()
            {
                [("a", "0")] = "OFF",
                [("a", "1")] = "ON",
                [("b", "0")] = "OFF",
                [("b", "1")] = "ON"
            };
            var initialState = "a";
            var finishStates = new List<string>() { "a", "b" };
            var actions = new Dictionary<string, Action>();
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
            dfa.FinalStates.Should().BeEquivalentTo(finishStates);

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
            var stateMap = new Dictionary<ValueTuple<string, string>, string>()
            {
                [("a", "0")] = "a",
                [("a", "1")] = "b",
                [("b", "0")] = "a",
                [("b", "1")] = "b"
            };
            var outMap = new Dictionary<ValueTuple<string, string>, string>()
            {
                [("a", "0")] = "OFF",
                [("a", "1")] = "ON",
                [("b", "0")] = "OFF",
                [("b", "1")] = "ON"
            };
            var initialState = "a";
            var finishStates = new List<string>() { "a", "b" };
            var actions = new Dictionary<string, Action>();
            var isNeedJournal = true;
            var isActionDeactivated = false;

            // When
            var dfa = (DfaModel)(new DfaModel())
                .AddTrasition("a", "a", "0", true, "OFF")
                .AddTrasition("a", "b", "1", true, "ON")
                .AddTrasition("b", "b", "1", true, "ON")
                .AddTrasition("b", "a", "0", true, "OFF")
                .SetInitialState("a")
                .SetIsNeedJournal(isNeedJournal)
                .SetIsNeedActionsDeactivate(isActionDeactivated);

            // Then
            dfa.StateMap.Should().BeEquivalentTo(stateMap);
            dfa.OutMap.Should().BeEquivalentTo(outMap);
            dfa.FinalStates.Should().BeEquivalentTo(finishStates);

            dfa.GetInitialState().Should().Be(initialState);
            dfa.IsNeedJournal().Should().BeTrue();
            dfa.IsActionsDeactivated().Should().BeFalse();

            dfa.GetCurrentState().Should().Be(initialState);

            dfa.IsFinal().Should().BeTrue();
            dfa.GetJournal().IsEmpty().Should().BeTrue();
        }
    }
}
