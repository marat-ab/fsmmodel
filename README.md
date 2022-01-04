# FsmModel
FsmModel is a library for creating and using Finite Automata (Finite State Machines).

____
# Install

____
# Description
## Repository structure
The repository contains the following projects:
- FsmModel - FSM Library
- FsmModel.Test - Project with tests. The NUnit 3 framework is used for testing.
- FsmModelDemo - Demo example of using the FsmModel library.
## FsmModel project structure
- Dfm - The section contains the DFA (Deterministic finite automaton) implementation.
- Journal - The section contains the Journal implementation for recording the operation of the machine.
- Utils - Some useful utilities (for example, for printing a Journal, etc.)
____
# Usage
Example of an automaton solving the problem of summing two binary numbers.
0. Add using directives:
```csharp
using FsmModel.Dfa;
using FsmModel.Utils;
```
1. Create DFA Model:
```csharp
var fsm = new DfaModel()
	.AddTrasition("q0", "q0", "00", true, "0")
	.AddTrasition("q0", "q0", "01", true, "1")
	.AddTrasition("q0", "q0", "10", true, "1")
	.AddTrasition("q0", "q1", "11", true, "0")
	.AddTrasition("q1", "q0", "00", true, "1")
	.AddTrasition("q1", "q1", "01", true, "0")
	.AddTrasition("q1", "q1", "10", true, "0")
	.AddTrasition("q1", "q1", "11", true, "1")
	.SetStartState("q0")
	.SetIsNeedJournal(true)
	.SetIsNeedActionsDeactivate(false);
 ```
 2. Send a sequence of signals to the input of the DFA machine:
 ```csharp
 fsm.Act("11")
	.Act("00")
	.Act("10")
	.Act("11")
	.Act("01")
	.Act("11")
	.Act("00")
	.Act("00");  
 ```
 3. Pring journal:
 ```csharp
 JournalUtils.PrintJournal(fsm.GetJournal());
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