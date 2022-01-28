using FluentAssertions;
using FsmModel.Journal;
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
        public void CreateEmptyFsmJournal()
        {
            // Given

            // When
            var journal = new FsmJournal();

            // Then
            journal.IsEmpty().Should().BeTrue();
            journal.GetJournalContent().Should().BeEmpty();
            journal.GetMaxItemLenght().Should().Be(0);
        }
    }
}
