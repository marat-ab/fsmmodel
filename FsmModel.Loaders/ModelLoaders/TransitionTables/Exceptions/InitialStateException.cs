using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class InitialStateException : Exception
    {
        public InitialStateException(string message)
            : base(message: $"Initial state ERROR: {message}.") { }
    }
}
