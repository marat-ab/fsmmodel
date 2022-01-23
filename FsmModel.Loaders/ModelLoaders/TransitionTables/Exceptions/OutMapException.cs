using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class OutMapException : Exception
    {
        public OutMapException(string message)
            : base(message: $"Out map ERROR: {message}.") { }
    }
}
