using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Journal
{
    public partial class FsmJournal: IFsmJournal
    {
        private readonly List<ValueTuple<string, string, string>> _journal = new();
        private int maxStateNameSize;
        private int maxSignalNameSize;
        private int maxOutMsgNameSize;

        public FsmJournal() { }

        private FsmJournal(List<ValueTuple<string, string, string>> journal)
        {
            _journal = journal.ToList();
            
            FillMaxNameSizes();
        }

        // IFsmJournal

        public void AddEvent(string state, string signal, string outMsg)
        {
            _journal.Add((state, signal, outMsg));
            UpdateMaxNameSizes(state, signal, outMsg);
        }

        public List<ValueTuple<string, string, string>> GetJournal() =>
            _journal.ToList();

        public bool IsEmpty() =>
            _journal.Count == 0 ? true : false;

        public void Clear() =>
            _journal.Clear();
            

        public int GetMaxStateNameSize() => maxStateNameSize;

        public int GetMaxSignalNameSize() => maxSignalNameSize;

        public int GetMaxOutMsgNameSize() => maxOutMsgNameSize;

        // Private
        private void UpdateMaxNameSizes(string state, string signal, string outMsg)
        {
            if (state.Length > maxStateNameSize)
                maxStateNameSize = state.Length;

            if (signal.Length > maxSignalNameSize)
                maxSignalNameSize = signal.Length;

            if (outMsg.Length > maxOutMsgNameSize)
                maxOutMsgNameSize = outMsg.Length;
        }

        private void FillMaxNameSizes()
        {
            maxStateNameSize = 0;
            maxSignalNameSize = 0;
            maxOutMsgNameSize = 0;
            
            foreach(var item in _journal)            
                UpdateMaxNameSizes(item.Item1, item.Item2, item.Item3);            
        }
    }
}
