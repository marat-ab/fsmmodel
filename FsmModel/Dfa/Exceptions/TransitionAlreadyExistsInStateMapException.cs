﻿using System;

namespace FsmModel.Dfa.Exceptions
{
    public class TransitionAlreadyExistsInStateMapException : Exception
    {
        public TransitionAlreadyExistsInStateMapException(string state, string signal)
            : base(message: $"Transition with head ({state}, {signal}) already exists in state map.") { }
    }
}