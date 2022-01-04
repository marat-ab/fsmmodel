using FsmModel.Journal;
using System;

namespace FsmModel.Dfm
{
    public interface IDfmModel
    {
        // Control

        IDfmModel Reset();

        IDfmModel Act(string signal);

        // Create and tuning

        IDfmModel AddTrasition(string fromState, string toState, string bySignal, bool isFinished, string outMsg, Action action);

        string GetStartState();

        IDfmModel SetStartState(string startState);

        IDfmModel SetIsNeedJournal(bool isNeedJournal);

        bool IsNeedJournal();

        IDfmModel SetIsNeedActionsDeactivate(bool isNeedActionDeactivate);

        bool IsActionsDeactivated();

        // Service

        string GetCurrentState();

        bool IsFinished();

        IFsmJournal GetJournal();

        void Clear();
    }
}
