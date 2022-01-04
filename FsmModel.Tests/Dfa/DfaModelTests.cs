using FsmModel.Dfa;

namespace FsmModel.Tests.Dfa
{
    partial class DfaModelTests
    {
        DfaModel CreateSimpleDfaModel() =>
            (DfaModel)(new DfaModel())
                .AddTrasition("a", "a", "0", false, "OFF")
                .AddTrasition("a", "b", "1", true, "ON")
                .AddTrasition("b", "b", "1", true, "ON")
                .AddTrasition("b", "a", "0", false, "OFF")
                .SetInitialState("a")
                .SetIsNeedJournal(true)
                .SetIsNeedActionsDeactivate(true);
    }
}
