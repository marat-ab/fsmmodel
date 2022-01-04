using FsmModel.Dfa;
using FsmModel.Utils;
using System;
using System.Linq;

namespace FsmModelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fsm = new DfaModel()
                .AddTrasition("q0", "q0", "00", true, "0", () => Print("0"))
                .AddTrasition("q0", "q0", "01", true, "1", () => Print("1"))
                .AddTrasition("q0", "q0", "10", true, "1", () => Print("1"))
                .AddTrasition("q0", "q1", "11", true, "0", () => Print("0"))

                .AddTrasition("q1", "q0", "00", true, "1", () => Print("1"))
                .AddTrasition("q1", "q1", "01", true, "0", () => Print("0"))
                .AddTrasition("q1", "q1", "10", true, "0", () => Print("0"))
                .AddTrasition("q1", "q1", "11", true, "1", () => Print("1"))

                .SetInitialState("q0")
                .SetIsNeedJournal(true)
                .SetIsNeedActionsDeactivate(false);

            fsm.Act("11").Act("00").Act("10").Act("11").Act("01").Act("11").Act("00").Act("00");

            JournalUtils.GetPrettyJournalContent(fsm.GetJournal())
                .ForEach(row => Console.WriteLine(row));
        }

        static void Print(string msg) =>
            Console.WriteLine(msg);
    }
}
