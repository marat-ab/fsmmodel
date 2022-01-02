using FsmModel.Journal;
using System;

namespace FsmModel.Utils
{
    public static class JournalUtils
    {
        public static void PrintJournal(IFsmJournal fsmJournal)
        {
            var journal = fsmJournal.GetJournal();
            Console.WriteLine(string.Format("|{0, -10}|{1, -10}|{2, -10}|", "Signal", "State", "Out Msg"));
            foreach (var v in journal)
            {
                Console.WriteLine(string.Format("|{0, -10}|{1, -10}|{2, -10}|", v.Item1, v.Item2, v.Item3));
            }
        }
    }
}
