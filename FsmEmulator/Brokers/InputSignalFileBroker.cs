using FsmModel.Loaders.Brokers.Files;
using FsmModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FsmEmulator.Brokers
{
    class InputSignalFileBroker : IFileBroker<IEnumerable<InSignal>>
    {
        public IEnumerable<InSignal> Load(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException($"File: {fileName}");

            var rawString = File.ReadAllText(fileName).Trim();

            rawString = rawString.Replace(Environment.NewLine, " ");

            var inputSignals = rawString.Split(' ').Select(v => new InSignal(v));

            return inputSignals;
        }
    }
}
