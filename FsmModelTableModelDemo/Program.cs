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
            var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var fileName = Path.Combine(
                dirName is null ? "" : dirName,
                "tablemodel.json"
            );

            var loader = new TransitionTableLoader(new FileBroker());

            var tableModel = loader.Load(fileName);

            var dfaModel = TransitionTableConverters.ToDfaModel(tableModel);

            dfaModel.Act(new("r1")).Act(new("r0")).Act(new("r1"));

            JournalUtils.GetPrettyJournalContent(dfaModel.GetJournal())
                .ForEach(row => Console.WriteLine(row));
        }
    }
}
