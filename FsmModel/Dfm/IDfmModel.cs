using FsmModel.Journal;
using System;
using System.Collections.Generic;

namespace FsmModel.Dfm
{
    public interface IDfmModel
    {
        IDfmModel Reset();

        IDfmModel Act(string signal);

        IDfmModel AddTrasition(string fromState, string toState, string bySignal, bool isFinished, string outMsg);

        IDfmModel SetStartState(string startState);

        IDfmModel SetIsNeedJournal(bool isNeedJournal);

        IDfmModel SetIsNeedDeactivateOutMsgs(bool isDeactivateOutMsgs);

        string GetCurrentState();

        bool IsFinished();

        IFsmJournal GetJournal();
    }
}
