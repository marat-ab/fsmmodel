using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Journal
{
    public partial class FsmJournal : ICloneable
    {
        public object Clone() =>
            new FsmJournal(_journal);        
    }
}
