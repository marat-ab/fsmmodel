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
        private List<List<string>> GetSimpleJournal() =>
            new List<List<string>>
            {
                new List<string> { "q0", "0", "OFF"},
                new List<string> { "q0", "1", "ON"},
                new List<string> { "q1", "0", "OFF" }
            };
    }
}
