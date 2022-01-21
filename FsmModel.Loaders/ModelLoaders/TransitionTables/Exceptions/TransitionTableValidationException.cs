using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class TransitionTableValidationException: Exception        
    {
        public TransitionTableValidationException(Exception innerException)
            : base(message: "Transition Table validation error occured.", innerException) { }
    }
}
