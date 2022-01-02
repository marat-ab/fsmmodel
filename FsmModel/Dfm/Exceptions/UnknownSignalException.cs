using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Dfm.Exceptions
{
    public class UnknownSignalException: Exception
    {
        public UnknownSignalException(string signal)
            :base(message: $"Unknown signal: {signal} error occured.") { }
    }
}
