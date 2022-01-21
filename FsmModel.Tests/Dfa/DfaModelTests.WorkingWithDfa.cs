using FluentAssertions;
using FsmModel.Models;
using NUnit.Framework;

namespace FsmModel.Tests.Dfa
{
    [TestFixture]
    partial class DfaModelTests
    {
        [Test]
        public void ResetStateOfDfa_StateWillResetAndJouralWillClear()
        {
            // Given
            var dfa = CreateSimpleDfaModel();

            // When
            dfa.Act(new("0")).Act(new("1")).Reset();

            // Then
            dfa.GetCurrentState().Should().Be(dfa.GetInitialState());
            dfa.IsFinal().Should().BeFalse();
            dfa.GetJournal().IsEmpty().Should().BeTrue();
        }

        [Test]
        public void DfaTransitionsAreOccured_StateAndEtcIsChanged()
        {
            // Given
            var dfa = CreateSimpleDfaModel();

            var countOfRowsInJournalBeforeReset = 2;
            var stateBeforeReset = new State("q1");

            // When
            dfa.Act(new("0")).Act(new("1"));
            var countOfRowsInJournal = dfa.GetJournal().GetJournalContent().Count;
            var currentState = dfa.GetCurrentState();
            var isFinalState = dfa.IsFinal();

            // Then
            countOfRowsInJournal.Should().Be(countOfRowsInJournalBeforeReset);
            currentState.Should().Be(stateBeforeReset);
            isFinalState.Should().BeTrue();
        }
    }
}
