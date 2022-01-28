using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class StateMapException : Exception
    {
        public StateMapException(string message)
            : base(message: $"State map ERROR: {message}.") { }
    }
}
