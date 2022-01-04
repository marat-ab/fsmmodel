using FsmModel.Journal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Utils
{
    public static class JournalUtils
    {
        public static void PrintJournal(IFsmJournal fsmJournal)
        {
            // Prepare
            var tableColNames = new List<string> { "Time", "Signal", "State", "Out msg" };

            var journal = fsmJournal.GetJournal();

            var size = (new List<int> { fsmJournal.GetMaxItemLenght() })
                        .Concat(tableColNames.Select(v => v.Length))
                        .Max();

            var tableHeader = "|" + string.Join("|", tableColNames.Select(v => v.PadRight(size))) + "|";
            var rowSeparator = new string('-', tableHeader.Length);

            // Print
            Console.WriteLine(rowSeparator);
            Console.WriteLine(tableHeader);
            Console.WriteLine(rowSeparator);

            foreach (var v in journal.Select((v, i) => new List<string> { i.ToString() }.Concat(v)).ToList())
            {
                var row = "|" + string.Join("|", v.Select(v => v.PadRight(size))) + "|";
                Console.WriteLine(row);
                Console.WriteLine(rowSeparator);
            }
        }
    }
}
