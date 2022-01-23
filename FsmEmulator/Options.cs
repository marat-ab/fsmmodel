using CommandLine;

namespace FsmEmulator
{
    public class Options
    {
        [Option('t', "transtable", Required = true, HelpText = "File with FSM (DFA) description in Transition table format")]
        public string TransitionTableFileName { get; set; }

        [Option('s', "signals", Required = true, HelpText = "File with a sequence of input signals for the FSM")]
        public string InputSignalsFileName { get; set; }
    }
}
