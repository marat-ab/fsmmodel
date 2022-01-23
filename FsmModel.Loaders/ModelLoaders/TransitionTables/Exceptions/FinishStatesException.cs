using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class FinishStatesException : Exception
    {
        public FinishStatesException(string message)
            : base(message: $"Finish states ERROR: {message}.") { }
    }
}
