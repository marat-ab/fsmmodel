using FsmModel.Loaders.Brokers.Files;
using FsmModel.Loaders.ModelLoaders.TransitionTables;
using FsmModel.Loaders.ModelLoaders.TransitionTables.Utils;
using FsmModel.Utils;
using System;
using System.IO;
using System.Reflection;

namespace FsmModelTableModelDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load transition table
            var transitionTable = LoadTransitionTable("tablemodel.json");

            // Convert TransitionTable into DfaModel
            var dfaModel = TransitionTableConverters.ToDfaModel(transitionTable);

            // Modeling
            dfaModel.Act(new("r1")).Act(new("r0")).Act(new("r1"));

            // Print Journal
            JournalUtils.GetPrettyJournalContent(dfaModel.GetJournal())
                .ForEach(row => Console.WriteLine(row));
        }

        static TransitionTable LoadTransitionTable(string fileName)
        {
            // Create fileName
            var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullFileName = Path.Combine(dirName is null ? "" : dirName, fileName);

            // Load transition table
            var loader = new TransitionTableLoader(new JsonFileBroker<TransitionTable>());
            var transitionTable = loader.Load(fullFileName);

            return transitionTable;
        }
    }
}
