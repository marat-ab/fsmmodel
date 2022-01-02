using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Journal
{
    public interface IFsmJournal
    {
        void AddEvent(string currentState, string signal, string outMsg);
        
        List<ValueTuple<string, string, string>> GetJournal();

        bool IsEmpty();

        void Clear();

        int GetMaxStateNameSize();

        int GetMaxSignalNameSize();

        int GetMaxOutMsgNameSize();

    }
}
