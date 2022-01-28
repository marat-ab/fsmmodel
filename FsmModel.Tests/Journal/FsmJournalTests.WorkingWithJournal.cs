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
