using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class ModelIsNotValidException: Exception
    {
        public ModelIsNotValidException()
            : base(message: "Model is not valid") { }
    }
}
