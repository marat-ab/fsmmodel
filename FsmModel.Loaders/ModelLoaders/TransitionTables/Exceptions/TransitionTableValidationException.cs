using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class TransitionTableValidationException : Exception
    {
        public TransitionTableValidationException(Exception innerException)
            : base(message: "Transition Table validation error occured.", innerException) { }
    }
}
