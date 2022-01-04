using System.Collections.Generic;

namespace FsmModel.Journal
{
    public interface IFsmJournal
    {
        void AddEvent(string currentState, string signal, string outSignal);

        List<List<string>> GetJournalContent();

        bool IsEmpty();

        void Clear();

        int GetMaxItemLenght();
    }
}
