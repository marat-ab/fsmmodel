using System;
using System.Collections.Generic;

namespace FsmModel.Journal.Exceptions
{
    public class BadRowInJournalException : Exception
    {
        public BadRowInJournalException(List<string> row)
            : base(message: $"Bad row in journal error occured. Row: {string.Join("|", row)}") { }
    }
}
