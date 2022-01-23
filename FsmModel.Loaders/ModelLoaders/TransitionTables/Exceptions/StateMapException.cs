using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class StateMapException: Exception
    {
        public StateMapException(string message)
            : base(message: $"State map ERROR: {message}.") { }
    }
}
