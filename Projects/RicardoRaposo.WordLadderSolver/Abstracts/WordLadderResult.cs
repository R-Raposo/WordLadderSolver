using System.Collections.Generic;

namespace RicardoRaposo.DotNetWordLadderSolver.Abstracts
{
    /// <summary>
    /// Abstraction for the solution of a Word Ladder
    /// </summary>
    public abstract class WordLadderResult
    {
        public abstract List<string> ResultSequence { get; set; }
    }
}
