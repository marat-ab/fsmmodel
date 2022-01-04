using FsmModel.Journal;
using System;

namespace FsmModel.Dfa
{
    public interface IDfaModel
    {
        // Control

        /// <summary>
        /// Reset state of DFA
        /// </summary>
        /// <returns>Current DFA</returns>
        IDfaModel Reset();

        /// <summary>
        /// Perform a state-transition function for input signal
        /// </summary>
        /// <param name="signal"></param>
        /// <returns>Current DFA</returns>
        IDfaModel Act(string signal);

        // Create and tuning

        /// <summary>
        /// Add transition into DFA model
        /// </summary>
        /// <param name="fromState">The state from which the transition will be occured</param>
        /// <param name="toState">The state to which the transition will be occured</param>
        /// <param name="bySignal">The input signal that will trigger the transition</param>
        /// <param name="isFinal">Is toState is one of final states</param>
        /// <param name="outMsg">Output of DFA when transition is occured</param>
        /// <param name="action">The function that will be called when the transition is occured</param>
        /// <returns>Current DFA</returns>
        IDfaModel AddTrasition(
            string fromState,
            string toState,
            string bySignal,
            bool isFinal,
            string outMsg,
            Action? action = null);

        /// <summary>
        /// Return initial state of DFA
        /// </summary>
        /// <returns>Initial state</returns>
        string GetInitialState();

        /// <summary>
        /// Set initial state of DFA
        /// </summary>
        /// <param name="initialState"></param>
        /// <returns>Current DFA</returns>
        IDfaModel SetInitialState(string initialState);

        /// <summary>
        /// Returns a flag indicating whether to keep a log of the machine operation or not
        /// </summary>
        /// <returns>True if necessary otherwise false</returns>
        bool IsNeedJournal();

        /// <summary>
        /// A flag indicating whether to keep a log of the operation of the machine or not
        /// </summary>
        /// <param name="isNeedJournal">True if necessary otherwise false</param>
        /// <returns>Current DFA<</returns>
        IDfaModel SetIsNeedJournal(bool isNeedJournal);

        /// <summary>
        /// Returns a flag indicating that an Action should be performed if a transition has been triggered
        /// </summary>
        /// <returns>True if necessary otherwise false</returns>
        bool IsActionsDeactivated();

        /// <summary>
        /// A flag indicating that an Action should be performed if a transition has been triggered
        /// </summary>
        /// <param name="isNeedActionDeactivate">True if necessary otherwise false</param>
        /// <returns>Current DFA</returns>
        IDfaModel SetIsNeedActionsDeactivate(bool isNeedActionDeactivate);

        // Service

        /// <summary>
        /// Return current state of DFA
        /// </summary>
        /// <returns>Current state of DFA</returns>
        string GetCurrentState();

        /// <summary>
        /// Return a flag indicating that state is final
        /// </summary>
        /// <returns>True if state is final otherwise false</returns>
        bool IsFinal();

        /// <summary>
        /// Return Journal as object that release IFsmJournal interfase
        /// </summary>
        /// <returns>Object that release IFsmJournal</returns>
        IFsmJournal GetJournal();

        /// <summary>
        /// Clear DFA description (states, actions, signals, etc.)
        /// </summary>
        void Clear();
    }
}
