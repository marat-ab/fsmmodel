using FsmModel.Dfa;
using FsmModel.Models;
using FsmModel.Utils;
using System;

namespace FsmModelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create States, Input Signals and Output Signals
            var q0 = new State("q0");
            var q1 = new State("q1");

            var s0 = new InSignal("00");
            var s1 = new InSignal("01");
            var s2 = new InSignal("10");
            var s3 = new InSignal("11");

            var r0 = new OutSignal("0");
            var r1 = new OutSignal("1");

            // Create DFA
            var dfa = new DfaModel()
                .AddTrasition(q0, q0, s0, true, r0, () => Print("0"))
                .AddTrasition(q0, q0, s1, true, r1, () => Print("1"))
                .AddTrasition(q0, q0, s2, true, r1, () => Print("1"))
                .AddTrasition(q0, q1, s3, true, r0, () => Print("0"))

                .AddTrasition(q1, q0, s0, true, r1, () => Print("1"))
                .AddTrasition(q1, q1, s1, true, r0, () => Print("0"))
                .AddTrasition(q1, q1, s2, true, r0, () => Print("0"))
                .AddTrasition(q1, q1, s3, true, r1, () => Print("1"))

                .SetInitialState(q0)
                .SetIsNeedJournal(true)
                .SetIsNeedActionsDeactivate(false);

            // Modeling
            dfa.Act(s3).Act(s0).Act(s2).Act(s3).Act(s1).Act(s3).Act(s0).Act(s0);

            // Print Journal
            JournalUtils.GetPrettyJournalContent(dfa.GetJournal())
                .ForEach(row => Console.WriteLine(row));
        }

        static void Print(string msg) =>
            Console.WriteLine(msg);
    }
}
