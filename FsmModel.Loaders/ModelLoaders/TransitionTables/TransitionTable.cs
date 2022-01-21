using FsmModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsmModel.Loaders.ModelLoaders.TransitionTables
{
    public class TransitionTable
    {
        public FsmType FsmType { get; set; }
        public string InitialState { get; set; }
        public List<string> FinalStates { get; set; }
        public bool IsNeedJournal { get; set; }
        public List<List<string>> StateMap { get; set; }
        public List<List<string>> OutMap { get; set; }
    }
}
