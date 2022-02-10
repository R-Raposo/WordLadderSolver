using System;
using System.Collections.Generic;
using System.Text;
using RicardoRaposo.DotNetWordLadderSolver.Abstracts;

namespace RicardoRaposo.DotNetWordLadderSolver.Interfaces
{
    /// <summary>
    /// Interface for word ladder solvers.
    /// <para>All implementations of this interface, must have a First and Last word of the ladder, and the string array of all possible words.</para>
    /// </summary>
    public interface IWordLadderSolver
    {
        /// <summary>
        /// First word of the word ladder
        /// </summary>
        string FirstWord { get; set; }
        /// <summary>
        /// Last word of the word ladder
        /// </summary>
        string LastWord { get; set; }
        /// <summary>
        /// List of words to contemplate
        /// </summary>
        string[] WordDictionary { get; set; }
        /// <summary>
        /// Solves the WordLadder and returns an implementation of a IWordLadderResult
        /// </summary>
        /// <returns></returns>
        WordLadderResult SolveWordLadder();
    }
}
