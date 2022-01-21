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
        public void BuildTestMapFromTransitionTable()
        {
            // Given
            var transTable = CreateTransitionTable();
            var expectedStateMap = new Dictionary<ValueTuple<State, Signal>, State>()
            {
                [(new("q0"), new("r0"))] = new("q0"),
                [(new("q0"), new("r1"))] = new("q1"),
                [(new("q1"), new("r0"))] = new("q0"),
                [(new("q1"), new("r1"))] = new("q1")
            };

            // When
            var stateMap = TransitionTableConverters.BuildStateMap(transTable);

            // Then
            stateMap.Should().BeEquivalentTo(expectedStateMap);
        }
    }
}
