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
        private readonly State q0 = new("q0");
        private readonly State q1 = new("q1");

        private readonly InSignal s0 = new("0");
        private readonly InSignal s1 = new("1");

        private readonly OutSignal r0 = new("OFF");
        private readonly OutSignal r1 = new("ON");

        private List<List<string>> GetSimpleJournal() =>
            new List<List<string>>
            {
                new List<string> { "q0", "0", "OFF"},
                new List<string> { "q0", "1", "ON"},
                new List<string> { "q1", "0", "OFF" }
            };
    }
}
