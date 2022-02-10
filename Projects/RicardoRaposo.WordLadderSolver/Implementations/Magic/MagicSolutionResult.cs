using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RicardoRaposo.DotNetWordLadderSolver.Abstracts;

namespace RicardoRaposo.DotNetWordLadderSolver.Implementations.Magic
{
    public class MagicSolutionResult : WordLadderResult
    {
        public override List<string> ResultSequence { get; set; }

        public MagicSolutionResult(string magicSolution)
        {
            // The Magic solution will be a single string
            // we must convert it to the type of the base class's 'ResultSequences'
            // while the Wizard is away, I just implemented a basic solution so the code will build.

            List<string> sequence =  magicSolution.Split(',').ToList();
            ResultSequence = sequence;
        }
    }
}
