using FsmModel.Models;
using System.Collections.Generic;

namespace FsmModel.Journal
{
    public interface IFsmJournal
    {
        void AddEvent(State state, InSignal inSignal, OutSignal outSignal);

        List<List<string>> GetJournalContent();

        bool IsEmpty();

        void Clear();

        int GetMaxItemLenght();
    }
}
