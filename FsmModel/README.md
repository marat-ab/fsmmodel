# FsmModel
FsmModel is a library for creating and using Finite Automata (Finite State Machines).

# Usage
## As a Library
Example of an automaton solving the problem of summing two binary numbers.

0. Add using directives
```csharp
using FsmModel.Dfa;
using FsmModel.Models;
using FsmModel.Utils;
```
1. Create States, InSignals and OutSignals
```csharp
var q0 = new State("q0");
var q1 = new State("q1");

var s0 = new InSignal("00");
var s1 = new InSignal("01");
var s2 = new InSignal("10");
var s3 = new InSignal("11");

var r0 = new OutSignal("0");
var r1 = new OutSignal("1");
```

2. Create DFA Model
```csharp
 var dfa = new DfaModel()
	.AddTrasition(q0, q0, s0, true, r0, () => Console.WriteLine("0"))
	.AddTrasition(q0, q0, s1, true, r1, () => Console.WriteLine("1"))
	.AddTrasition(q0, q0, s2, true, r1, () => Console.WriteLine("1"))
	.AddTrasition(q0, q1, s3, true, r0, () => Console.WriteLine("0"))

	.AddTrasition(q1, q0, s0, true, r1, () => Console.WriteLine("1"))
	.AddTrasition(q1, q1, s1, true, r0, () => Console.WriteLine("0"))
	.AddTrasition(q1, q1, s2, true, r0, () => Console.WriteLine("0"))
	.AddTrasition(q1, q1, s3, true, r1, () => Console.WriteLine("1"))

	.SetInitialState(q0)
	.SetIsNeedJournal(true)
	.SetIsNeedActionsDeactivate(false);
 ```
 3. Send a sequence of signals to the input of the DFA machine
 ```csharp
dfa.Act(s3)
 .Act(s0)
 .Act(s2)
 .Act(s3)
 .Act(s1)
 .Act(s3)
 .Act(s0)
 .Act(s0);  
 ```
 3. Print journal
 ```csharp
JournalUtils.GetPrettyJournalContent(dfa.GetJournal())
    .ForEach(row => Console.WriteLine(row));
 ```
 The printed journal will look something like this
 ```
 ---------------------------------
|Time   |Signal |State  |Out msg|
---------------------------------
|0      |11     |q0     |0      |
---------------------------------
|1      |00     |q1     |1      |
---------------------------------
|2      |10     |q0     |1      |
---------------------------------
|3      |11     |q0     |0      |
---------------------------------
|4      |01     |q1     |0      |
---------------------------------
|5      |11     |q1     |1      |
---------------------------------
|6      |00     |q1     |1      |
---------------------------------
|7      |00     |q0     |0      |
---------------------------------
 ```

 ## FSM Emulator
 Example using FsmEmulator

 0. Create TransitionTable model in JSON format and save it in file (tablemodel.json).
 ```json
 {
  "Type": "DFA",
  "InitialState": "q0",
  "FinishStates": [ "q0", "q1" ],
  "IsNeedJournal": true,
  "StateMap": [
    [ "-",  "00", "01", "10", "11" ],
    [ "q0", "q0", "q0", "q0", "q1" ],
    [ "q1", "q0", "q1", "q1", "q1" ]    
  ],
  "OutMap": [
    [ "-", "00", "01", "10", "11" ],
    [ "q0", "0", "1", "1", "0" ],
    [ "q1", "1", "0", "0", "1" ]
  ]
}
 ```

 1. Create a sequence of signals and save it to a file (SignalsSeq.txt)
 ```
 11 00 10 11 01 11 00 00 00 00 00 00
 ```

 2. Run FsmEmulator
 ```
 FsmEmulator -t tablemodel.json -s SignalSeq.txt

 ```