# FsmModel.Loaders
FsmModel.Loaders is a library with tools for loading transition tables from files and convert it into DFA models.

# Usage

0. Add using directives:
```csharp
using FsmModel.Loaders.Brokers.Files;
using FsmModel.Loaders.ModelLoaders.TransitionTables;
using FsmModel.Loaders.ModelLoaders.TransitionTables.Utils;
using FsmModel.Utils;
```
1. Load transition table:
```csharp
var loader = new TransitionTableLoader(new JsonFileBroker<TransitionTable>());
var transitionTable = loader.Load("TransitionTable.json");
```

2. Convert TransitionTable into DfaModel:
```csharp
 var dfaModel = TransitionTableConverters.ToDfaModel(transitionTable);
 ```

3. Modeling:
 ```csharp
dfaModel.Act(new("r1")).Act(new("r0")).Act(new("r1"));  
 ```

4. Print journal:
 ```csharp
JournalUtils.GetPrettyJournalContent(dfaModel.GetJournal())
    .ForEach(row => Console.WriteLine(row));
 ```

TransitionTable.json file:
 ```json
{
  "Type": "DFA",
  "InitialState": "q0",
  "FinishStates": [ "q0", "q1" ],
  "IsNeedJournal": true,
  "StateMap": [
    [ "-", "r0", "r1" ],
    [ "q0", "q0", "q1" ],
    [ "q1", "q0", "q1" ]    
  ],
  "OutMap": [
    [ "-", "r0", "r1" ],
    [ "q0", "OFF", "ON" ],
    [ "q1", "OFF", "ON" ]
  ]
}
 ```