﻿using FsmModel.Loaders.ModelLoaders.TransitionTables;
using FsmModel.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.Tests.ModelLoaders.TransitionTables.Utils
{
    [TestFixture]
    partial class TransitionTableConvertersTests
    {
        private static TransitionTable CreateTransitionTable() =>
            new()
            {
                FsmType = FsmType.DFA,
                InitialState = "q0",
                FinalStates = new() { "q0", "q1" },
                IsNeedJournal = true,
                StateMap = new()
                {
                    new() { "-", "r0", "r1" },
                    new() { "q0", "q0", "q1" },
                    new() { "q1", "q0", "q1" }
                },
                OutMap = new()
                {
                    new() { "-", "r0", "r1" },
                    new() { "q0", "OFF", "ON" },
                    new() { "q1", "OFF", "ON" }
                }
            };            
    }
}