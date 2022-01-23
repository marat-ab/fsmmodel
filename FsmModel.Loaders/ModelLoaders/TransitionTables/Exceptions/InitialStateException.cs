using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class InitialStateException : Exception
    {
        public InitialStateException(string message)
            : base(message: $"Initial state ERROR: {message}.") { }
    }
}
