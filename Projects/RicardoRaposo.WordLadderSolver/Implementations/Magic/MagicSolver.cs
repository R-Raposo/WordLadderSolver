using System;
using RicardoRaposo.DotNetWordLadderSolver.Abstracts;
using RicardoRaposo.DotNetWordLadderSolver.Interfaces;

namespace RicardoRaposo.DotNetWordLadderSolver.Implementations.Magic
{
    /// <summary>
    /// Class that uses Magic to build a solution to the WordLadder game
    /// </summary>
    public class MagicSolver : IWordLadderSolver
    {
        public string FirstWord { get; set; }
        public string LastWord { get; set; }
        public string[] WordDictionary { get; set; }

        public MagicSolver()
        {

        }

        /// <summary>
        /// The wizard is on vacation, magic method not yet implemented.
        /// <para></para>In the meanwhile, please use the BADS solution here: <seealso cref="BADS.BreadthAndDepthSearchSolver"/>
        /// </summary>
        /// <returns></returns>
        public WordLadderResult SolveWordLadder()
        {
            throw new NotImplementedException();
        }
    }
}
