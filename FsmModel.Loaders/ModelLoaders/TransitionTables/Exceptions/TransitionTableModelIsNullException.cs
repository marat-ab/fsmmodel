using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class TransitionTableModelIsNullException: Exception
    {
        public TransitionTableModelIsNullException()
            :base(message: "Transition table model is Null.") { }
    }
}
