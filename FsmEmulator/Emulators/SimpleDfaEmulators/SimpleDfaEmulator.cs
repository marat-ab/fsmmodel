using FsmModel.Dfa;
using FsmModel.Models;
using FsmModel.Utils;
using System;
using System.Collections.Generic;

namespace FsmEmulator.Emulators.SimpleDfaEmulators
{
    class SimpleDfaEmulator
    {
        private readonly IDfaModel _dfaModel;
        public SimpleDfaEmulator(IDfaModel dfaModel) =>
            _dfaModel = dfaModel;

        public void RunEmulation(IEnumerable<InSignal> inputSignalsSeq)
        {
            foreach (var s in inputSignalsSeq)
                _dfaModel.Act(s);
        }

        public void PrintResults()
        {
            if (_dfaModel.IsNeedJournal())
            {
                JournalUtils.GetPrettyJournalContent(_dfaModel.GetJournal())
                    .ForEach(row => Console.WriteLine(row));
            }
            else
            {
                Console.WriteLine("Journal is absent!");
            }
        }
    }
}
