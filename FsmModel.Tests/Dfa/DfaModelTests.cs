using FsmModel.Dfa;
using FsmModel.Models;

namespace FsmModel.Tests.Dfa
{
    partial class DfaModelTests
    {
        DfaModel CreateSimpleDfaModel()
        {
            var q0 = new State("q0");
            var q1 = new State("q1");

            var s0 = new InSignal("0");
            var s1 = new InSignal("1");

            var r0 = new OutSignal("OFF");
            var r1 = new OutSignal("ON");

            return (DfaModel)(new DfaModel())
                .AddTrasition(q0, q0, s0, false, r0)
                .AddTrasition(q0, q1, s1, true, r1)
                .AddTrasition(q1, q0, s0, false, r0)
                .AddTrasition(q1, q1, s1, true, r1)
                .SetInitialState(q0)
                .SetIsNeedJournal(true)
                .SetIsNeedActionsDeactivate(true);
        }
    }
}
