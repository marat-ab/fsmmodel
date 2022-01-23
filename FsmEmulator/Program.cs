using CommandLine;
using FsmEmulator.Emulators;
using FsmModel.Dfa;
using FsmModel.Loaders.Brokers.Files;
using FsmModel.Loaders.ModelLoaders.TransitionTables;
using FsmModel.Loaders.ModelLoaders.TransitionTables.Utils;
using FsmModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FsmEmulator
{
    class Program
    {
        static void Main(string[] args) =>        
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        
        static void RunOptions(Options opts)
        {
            var dfaModel = EmulatorUtils.LoadFsmModel(opts.TransitionTableFileName);
            var inputSignals = EmulatorUtils.LoadInputSignalsSeq(opts.InputSignalsFileName);

            var emulator = new SimpleDfaEmulator(dfaModel);
            emulator.RunEmulation(inputSignals);
            emulator.PrintResults();
        }

        static void HandleParseError(IEnumerable<Error> errs) { }        
    }
}
