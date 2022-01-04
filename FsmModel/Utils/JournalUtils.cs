using FsmModel.Journal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Utils
{
    public static class JournalUtils
    {
        public static List<string> GetPrettyJournalContent(IFsmJournal fsmJournal)
        {
            // Prepare
            var content = new List<string>();

            var tableColNames = new List<string> { "Time", "Signal", "State", "Out msg" };

            var journal = fsmJournal.GetJournalContent();

            var size = (new List<int> { fsmJournal.GetMaxItemLenght() })
                        .Concat(tableColNames.Select(v => v.Length))
                        .Max();

            var tableHeader = "|" + string.Join("|", tableColNames.Select(v => v.PadRight(size))) + "|";
            var rowSeparator = new string('-', tableHeader.Length);

            // Generate content
            content.Add(rowSeparator);
            content.Add(tableHeader);
            content.Add(rowSeparator);

            foreach (var v in journal.Select((v, i) => new List<string> { i.ToString() }.Concat(v)).ToList())
            {
                var row = "|" + string.Join("|", v.Select(v => v.PadRight(size))) + "|";
                content.Add(row);
                content.Add(rowSeparator);
            }

            return content;
        }
    }
}
