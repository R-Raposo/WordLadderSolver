using System.Collections.Generic;
using RicardoRaposo.DotNetWordLadderSolver.Abstracts;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RRWLTester")]
namespace RicardoRaposo.DotNetWordLadderSolver.Implementations.BADS
{
    internal class BreadthAndDepthSearchResult : WordLadderResult
    {
        public override List<string> ResultSequence { get; set; }

        public BreadthAndDepthSearchResult(List<List<string>> BADSResult)
        {
            if(BADSResult == null || BADSResult.Count == 0)
            {
                // No solution found, return empty list of strings
                ResultSequence = new List<string>();
            }
            else
            {
                // Solution found! Return the first solution found, even though there could be many
                ResultSequence = BADSResult[0];
            }
        }
    }
}
