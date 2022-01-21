using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class ModelIsNotValidException : Exception
    {
        public ModelIsNotValidException()
            : base(message: "Model is not valid") { }
    }
}
