using FsmModel.Journal.Exceptions;
using FsmModel.Models;
using System.Collections.Generic;
using System.Linq;

namespace FsmModel.Journal
{
    public partial class FsmJournal : IFsmJournal
    {
        private readonly List<List<string>> _journal = new();
        private int _maxItemLength;

        public FsmJournal() { }

        private FsmJournal(List<List<string>> journal)
        {
            _journal = journal.Select(v => v.ToList())
                            .ToList();

            FillMaxNameSizes();
        }

        // IFsmJournal

        public void AddEvent(State state, InSignal inSignal, OutSignal outSignal)
        {
            var stateValue = state.ToString();
            var inSignalValue = inSignal.ToString();
            var outSignalValue = outSignal.ToString();

            _journal.Add(new() { stateValue, inSignalValue, outSignalValue });

            UpdateMaxNameSizes(stateValue, inSignalValue, outSignalValue);
        }

        public List<List<string>> GetJournalContent() =>
            _journal.Select(v => v.ToList())
                .ToList();

        public bool IsEmpty() =>
            _journal.Count == 0;

        public void Clear()
        {
            _journal.Clear();
            _maxItemLength = 0;
        }

        public int GetMaxItemLenght() =>
            _maxItemLength;

        // Private
        private void UpdateMaxNameSizes(string state, string inSignal, string outSignal)
        {            
            if (state.Length > _maxItemLength)
                _maxItemLength = state.Length;

            if (inSignal.Length > _maxItemLength)
                _maxItemLength = inSignal.Length;

            if (outSignal.Length > _maxItemLength)
                _maxItemLength = outSignal.Length;
        }

        private void FillMaxNameSizes()
        {
            _maxItemLength = 0;

            foreach (var item in _journal)
            {
                if (item.Count == 3)
                    UpdateMaxNameSizes(item[0], item[1], item[2]);
                else
                    throw new BadRowInJournalException(item);
            }
        }
    }
}
