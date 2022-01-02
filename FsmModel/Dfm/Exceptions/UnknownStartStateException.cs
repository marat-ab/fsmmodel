using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Dfm.Exceptions
{
    public class UnknownStartStateException: Exception
    {
        public UnknownStartStateException(string state)
            : base(message: $"Unknown start state: {state} error.") { }
    }
}
