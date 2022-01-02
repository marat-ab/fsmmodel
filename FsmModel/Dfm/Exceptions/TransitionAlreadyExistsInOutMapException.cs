using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Dfm.Exceptions
{
    public class TransitionAlreadyExistsInOutMapException : Exception
    {
        public TransitionAlreadyExistsInOutMapException(string state, string signal)
            : base(message: $"Transition with head ({state}, {signal}) already exists in out map.") { }
    }
}
