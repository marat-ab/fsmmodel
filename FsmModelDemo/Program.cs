using FsmModel.Dfm;
using FsmModel.Journal;
using FsmModel.Utils;
using System;

namespace FsmModelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fsm = new DfmModel().AddTrasition("a", "a", "0", true, "OFF")
                .AddTrasition("a", "b", "1", true, "ON")
                .AddTrasition("b", "b", "1", true, "ON")
                .AddTrasition("b", "a", "0", true, "OFF")
                .SetStartState("a")
                .SetIsNeedJournal(true);

            fsm.Act("0").Act("1").Act("0").Act("1");
            

            JournalUtils.PrintJournal(fsm.GetJournal());
        }
    }
}
