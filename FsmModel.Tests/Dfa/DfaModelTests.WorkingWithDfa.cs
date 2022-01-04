using FluentAssertions;
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
            dfa.Act("0").Act("1").Reset();

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

            int countOfRowsInJournalBeforeReset = 2;
            string stateBeforeReset = "b";

            // When
            dfa.Act("0").Act("1");
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
