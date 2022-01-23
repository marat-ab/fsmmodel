using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class OutMapException : Exception
    {
        public OutMapException(string message)
            : base(message: $"Out map ERROR: {message}.") { }
    }
}
