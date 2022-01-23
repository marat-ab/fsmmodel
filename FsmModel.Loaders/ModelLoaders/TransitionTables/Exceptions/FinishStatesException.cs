using System;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables.Exceptions
{
    class FinishStatesException : Exception
    {
        public FinishStatesException(string message)
            : base(message: $"Finish states ERROR: {message}.") { }
    }
}
