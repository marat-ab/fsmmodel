using FluentAssertions;
using FsmModel.Dfm;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FsmModel.Tests.Dfm
{
    [TestFixture]
    class DfmModelTests
    {
        [Test]
        public void CreateEmptyDfmModel_NormallyCreated()
        {
            // Given
            var emptyStateMap = new Dictionary<ValueTuple<string, string>, string>();
            var emptyOutMap = new Dictionary<ValueTuple<string, string>, string>();
            var unsettedStartState = "";
            var emptyFinishStates = new List<string>();

            // When
            var dfmEmpty = new DfmModel();

            // Then
            dfmEmpty.StateMap.Should().BeEquivalentTo(emptyStateMap);
            dfmEmpty.OutMap.Should().BeEquivalentTo(emptyOutMap);
            dfmEmpty.FinishStates.Should().BeEquivalentTo(emptyFinishStates);

            dfmEmpty.StartState.Should().Be(unsettedStartState);
            dfmEmpty.IsNeedJournal.Should().BeFalse();
            dfmEmpty.IsDeactivateOutMsgs.Should().BeTrue();

            dfmEmpty.IsFinished().Should().BeFalse();
            dfmEmpty.GetJournal().IsEmpty().Should().BeTrue();
        }

        [Test]
        public void CreateByCtorWithAllArgs_NormallyCreated()
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
            var startState = "a";
            var finishStates = new List<string>() { "a", "b" };
            var isNeedJournal = true;
            var isDeactivateOutMsg = false;

            // When
            var dfm = new DfmModel(stateMap, outMap, startState, finishStates, isNeedJournal, isDeactivateOutMsg);

            // Then
            dfm.StateMap.Should().BeEquivalentTo(stateMap);
            dfm.OutMap.Should().BeEquivalentTo(outMap);
            dfm.FinishStates.Should().BeEquivalentTo(finishStates);

            dfm.StartState.Should().Be(startState);
            dfm.IsNeedJournal.Should().BeTrue();
            dfm.IsDeactivateOutMsgs.Should().BeFalse();

            dfm.GetCurrentState().Should().Be(startState);

            dfm.IsFinished().Should().BeTrue();
            dfm.GetJournal().IsEmpty().Should().BeTrue();
        }

        [Test]
        public void CreateDfmByFluentApi_NormallyCreated()
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
            var startState = "a";
            var finishStates = new List<string>() { "a", "b" };
            var isNeedJournal = true;
            var isDeactivateOutMsg = false;

            // When
            var dfm = (DfmModel)(new DfmModel()).AddTrasition("a", "a", "0", true, "OFF")
               .AddTrasition("a", "b", "1", true, "ON")
               .AddTrasition("b", "b", "1", true, "ON")
               .AddTrasition("b", "a", "0", true, "OFF")
               .SetStartState("a")
               .SetIsNeedJournal(isNeedJournal)
               .SetIsNeedActionsDeactivate(isDeactivateOutMsg);

            // Then
            dfm.StateMap.Should().BeEquivalentTo(stateMap);
            dfm.OutMap.Should().BeEquivalentTo(outMap);
            dfm.FinishStates.Should().BeEquivalentTo(finishStates);

            dfm.StartState.Should().Be(startState);
            dfm.IsNeedJournal.Should().BeTrue();
            dfm.IsDeactivateOutMsgs.Should().BeFalse();

            dfm.GetCurrentState().Should().Be(startState);

            dfm.IsFinished().Should().BeTrue();
            dfm.GetJournal().IsEmpty().Should().BeTrue();
        }
    }
}
