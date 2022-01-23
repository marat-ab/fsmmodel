using FsmEmulator.Brokers;
using FsmModel.Dfa;
using FsmModel.Loaders.Brokers.Files;
using FsmModel.Loaders.ModelLoaders.TransitionTables;
using FsmModel.Loaders.ModelLoaders.TransitionTables.Utils;
using FsmModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmEmulator.Emulators
{
    static class EmulatorUtils
    {
        public static IDfaModel LoadFsmModel(string fileName)
        {
            // Load transition table
            var loader = new TransitionTableLoader(new JsonFileBroker<TransitionTable>());
            var transitionTable = loader.Load(fileName);

            // Convert TransitionTable into DfaModel
            var dfaModel = TransitionTableConverters.ToDfaModel(transitionTable);

            return dfaModel;
        }

        public static IEnumerable<InSignal> LoadInputSignalsSeq(string fileName)
        {
            var broker = new InputSignalFileBroker();
            return broker.Load(fileName);
        }
    }
}
