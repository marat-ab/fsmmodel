using CommandLine;
using FsmEmulator.Emulators;
using FsmEmulator.Emulators.SimpleDfaEmulators;
using System.Collections.Generic;

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
