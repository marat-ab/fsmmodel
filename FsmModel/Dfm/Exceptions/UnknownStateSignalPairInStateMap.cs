using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Dfm.Exceptions
{
    class UnknownStateSignalPairInStateMap: Exception
    {
        public UnknownStateSignalPairInStateMap(string current_state, string signal)
            : base(message: $"Pair ({current_state}, {signal}) is absent in state map."){ }
    }
}
