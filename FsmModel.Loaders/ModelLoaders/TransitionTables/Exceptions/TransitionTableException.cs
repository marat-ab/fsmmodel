using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class TransitionTableException: Exception
    {
        public TransitionTableException(Exception innerException)
            : base(message: "Transition Table error occured.", innerException) { }
    }
}
