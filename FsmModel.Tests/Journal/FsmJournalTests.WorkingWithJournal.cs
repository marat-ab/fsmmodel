using FluentAssertions;
using FsmModel.Journal;
using FsmModel.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Tests.Journal
{
    [TestFixture]
    internal partial class FsmJournalTests
    {
        [Test]
        public void AddEventsIntoJournal()
        {
            // Given
            var q0 = new State("q0");
            var q1 = new State("q1");

            var s0 = new InSignal("0");
            var s1 = new InSignal("1");

            var r0 = new OutSignal("OFF");
            var r1 = new OutSignal("ON");

            var journal = new FsmJournal();

            // When
            journal.AddEvent(q0, s0, r0);
            journal.AddEvent(q0, s1, r1);
            journal.AddEvent(q1, s0, r0);

            // Then
            journal.IsEmpty().Should().BeFalse();
            journal.GetMaxItemLenght().Should().Be(3);
            journal.GetJournalContent().Should().BeEquivalentTo(GetSimpleJournal());
        }

        [Test]
        public void ClearFsmJournal()
        {
            // Given
            var q0 = new State("q0");
            var q1 = new State("q1");

            var s0 = new InSignal("0");
            var s1 = new InSignal("1");

            var r0 = new OutSignal("OFF");
            var r1 = new OutSignal("ON");

            var journal = new FsmJournal();

            // When
            journal.AddEvent(q0, s0, r0);
            journal.AddEvent(q0, s1, r1);
            journal.AddEvent(q1, s0, r0);

            journal.Clear();

            // Then
            journal.IsEmpty().Should().BeTrue();
            journal.GetJournalContent().Should().BeEmpty();
            journal.GetMaxItemLenght().Should().Be(0);
        }

        [Test]
        public void CloneFsmJournal()
        {
            // Given
            var q0 = new State("q0");
            var q1 = new State("q1");

            var s0 = new InSignal("0");
            var s1 = new InSignal("1");

            var r0 = new OutSignal("OFF");
            var r1 = new OutSignal("ON");

            var journal = new FsmJournal();
                        
            journal.AddEvent(q0, s0, r0);
            journal.AddEvent(q0, s1, r1);
            journal.AddEvent(q1, s0, r0);

            // When
            var journalCopy = (FsmJournal)journal.Clone();

            // Then
            journal.IsEmpty().Should().Be(journalCopy.IsEmpty());
            journal.GetMaxItemLenght().Should().Be(journalCopy.GetMaxItemLenght());
            journal.GetJournalContent().Should().BeEquivalentTo(journalCopy.GetJournalContent());
        }
    }
}
