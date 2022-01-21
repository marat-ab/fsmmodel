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
            // Create fileName

            var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileName = Path.Combine(dirName is null ? "" : dirName, "tablemodel.json");

            // Load transition table
            var loader = new TransitionTableLoader(new FileBroker());
            var transitionTable = loader.Load(fileName);

            // Convert TransitionTable into DfaModel
            var dfaModel = TransitionTableConverters.ToDfaModel(transitionTable);

            // Modeling
            dfaModel.Act(new("r1")).Act(new("r0")).Act(new("r1"));

            // Print Journal
            JournalUtils.GetPrettyJournalContent(dfaModel.GetJournal())
                .ForEach(row => Console.WriteLine(row));
        }
    }
}
