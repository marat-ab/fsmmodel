using System;

namespace FsmModel.Journal
{
    public partial class FsmJournal : ICloneable
    {
        public object Clone() =>
            new FsmJournal(_journal);
    }
}
