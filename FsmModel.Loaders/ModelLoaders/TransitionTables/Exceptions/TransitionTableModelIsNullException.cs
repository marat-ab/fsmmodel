using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class TransitionTableModelIsNullException : Exception
    {
        public TransitionTableModelIsNullException()
            : base(message: "Transition table model is Null.") { }
    }
}
