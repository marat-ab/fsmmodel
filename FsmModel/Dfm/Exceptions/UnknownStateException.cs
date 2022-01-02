using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Dfm.Exceptions
{
    public class UnknownStateException: Exception
    {
        public UnknownStateException(string state)
            : base(message: $"Unknown state: {state} error.") { }
    }
}
