using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class TransitionTableException : Exception
    {
        public TransitionTableException(Exception innerException)
            : base(message: "Transition Table error occured.", innerException) { }
    }
}
