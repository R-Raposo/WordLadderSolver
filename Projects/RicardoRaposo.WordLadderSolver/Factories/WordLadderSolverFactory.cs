using RicardoRaposo.DotNetWordLadderSolver.Implementations.BADS;
using RicardoRaposo.DotNetWordLadderSolver.Implementations.Magic;
using RicardoRaposo.DotNetWordLadderSolver.Interfaces;
using RicardoRaposo.DotNetWordLadderSolver.WordLadderInputParameters;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RicardoRaposo.DotNetWordLadderSolver.Enums;

[assembly: InternalsVisibleTo("RRWLTester")]
namespace RicardoRaposo.DotNetWordLadderSolver.Factories
{
 
    internal class WordLadderSolverFactory
    {
        public static IWordLadderSolver GetSolver(WordLadderSolverType solverType, WordLadderParameters parameters)
        {
            return solverType switch
            {
                WordLadderSolverType.BADS => new BreadthAndDepthSearchSolver(parameters),
                WordLadderSolverType.Magic => new MagicSolver(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
