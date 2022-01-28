using FluentAssertions;
using FsmModel.Journal;
using FsmModel.Models;
using FsmModel.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Tests.Utils
{
    [TestFixture]
    internal class JournalUtilsTests
    {
        [Test]
        public void BuildPrettyTableForEmptyJournal()
        {
            // Given
            var journal = new FsmJournal();

            var expectedText = new List<string>
            {
                "---------------------------------",
                "|Time   |State  |Signal |Out msg|",
                "---------------------------------"
            };

            // When
            var journalPrettyFormat = JournalUtils.GetPrettyJournalContent(journal);

            // Then
            journalPrettyFormat.Should().BeEquivalentTo(expectedText);
        }

        [Test]
        public void BuildPrettyTableForJournalWithContent()
        {
            // Given
            State q0 = new("q0");
            State q1 = new("q1");

            InSignal s0 = new("0");
            InSignal s1 = new("1");

            OutSignal r0 = new("OFF");
            OutSignal r1 = new("ON");
            
            var journal = new FsmJournal();

            journal.AddEvent(q0, s0, r0);
            journal.AddEvent(q0, s1, r1);
            journal.AddEvent(q1, s0, r0);

            var expectedText = new List<string>
            {
                "---------------------------------",
                "|Time   |State  |Signal |Out msg|",
                "---------------------------------",
                "|0      |q0     |0      |OFF    |",
                "---------------------------------",
                "|1      |q0     |1      |ON     |",
                "---------------------------------",
                "|2      |q1     |0      |OFF    |",
                "---------------------------------"
            };

            // When
            var journalPrettyFormat = JournalUtils.GetPrettyJournalContent(journal);

            // Then
            journalPrettyFormat.Should().BeEquivalentTo(expectedText);
        }
    }
}
