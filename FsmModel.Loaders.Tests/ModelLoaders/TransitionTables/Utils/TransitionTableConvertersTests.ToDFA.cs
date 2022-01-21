using FluentAssertions;
using FsmModel.Loaders.ModelLoaders.TransitionTables.Utils;
using FsmModel.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.Tests.ModelLoaders.TransitionTables.Utils
{
    [TestFixture]
    partial class TransitionTableConvertersTests
    {
        [Test]
        public void BuildDfaModelFromTransitionTable()
        {
            // Given
            var transTable = CreateTransitionTable();
            var expectedStateMap = new Dictionary<ValueTuple<State, InSignal>, State>()
            {
                [(new("q0"), new("r0"))] = new("q0"),
                [(new("q0"), new("r1"))] = new("q1"),
                [(new("q1"), new("r0"))] = new("q0"),
                [(new("q1"), new("r1"))] = new("q1")
            };

            var expectedOutMap = new Dictionary<ValueTuple<State, InSignal>, OutSignal>()
            {
                [(new("q0"), new("r0"))] = new("OFF"),
                [(new("q0"), new("r1"))] = new("ON"),
                [(new("q1"), new("r0"))] = new("OFF"),
                [(new("q1"), new("r1"))] = new("ON")
            };

            var expectedInitialState = new State("q0");
            var expectedFinishStates = new List<State> { new("q0"), new("q1") };
            
            // When
            var dfa = TransitionTableConverters.ToDfaModel(transTable);

            // Then
            dfa.StateMap.Should().BeEquivalentTo(expectedStateMap);
            dfa.OutMap.Should().BeEquivalentTo(expectedOutMap);
            dfa.GetInitialState().Should().Be(expectedInitialState);
            dfa.FinishStates.Should().BeEquivalentTo(expectedFinishStates);
            dfa.IsNeedJournal().Should().BeTrue();
            dfa.IsActionsDeactivated().Should().BeTrue();
        }
    }
}
