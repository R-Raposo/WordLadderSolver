using RicardoRaposo.DotNetWordLadderSolver.Abstracts;
using RicardoRaposo.DotNetWordLadderSolver.Interfaces;
using RicardoRaposo.DotNetWordLadderSolver.WordLadderInputParameters;
using RicardoRaposo.DotNetWordLadderSolver.Enums;
using RicardoRaposo.DotNetWordLadderSolver.Factories;
using System;

namespace RicardoRaposo.DotNetWordLadderSolver
{
    public class WordLadderSolutionBuilder
    {
        private static string _firstWord;
        private static string FirstWord
        {
            get { return _firstWord.ToLower(); }
            set { _firstWord = value; }
        }

        private static string _lastWord;
        private static string LastWord
        {
            get { return _lastWord.ToLower(); }
            set { _lastWord = value; }
        }

        private static string[] WordsList
        {
            get; 
            set;
        }

        private static WordLadderSolverType SolverType { get; set; }

        /// <param name="firstWord">First word of the word ladder</param>
        /// <param name="lastWord">Last word of the word ladder</param>
        /// <param name="wordsList">Array of words to use</param>
        /// <param name="solverType">The solver type to be used. Default is BADS solver</param>
        public WordLadderSolutionBuilder(string firstWord, string lastWord, string[] wordsList, WordLadderSolverType solverType = WordLadderSolverType.BADS)
        {
            if(string.IsNullOrWhiteSpace(firstWord))
            {
                throw new ArgumentNullException("firstName", "firstWord argument can not be null.");
            }

            if (string.IsNullOrWhiteSpace(lastWord))
            {
                throw new ArgumentNullException("lastWord", "lastWord argument can not be null.");
            }

            if (wordsList == null || wordsList.Length == 0)
            {
                throw new ArgumentException("wordsList", "wordsList argument can not be null or empty.");
            }

            FirstWord = firstWord;
            LastWord = lastWord;
            WordsList = wordsList;
            SolverType = solverType;
        }

        public string GetSolution()
        {
            return GetSolution(FirstWord, LastWord, WordsList);
        }

        public static string GetSolution(string firstWord, string lastWord, string[] wordsList, WordLadderSolverType solverType = WordLadderSolverType.BADS)
        {
            FirstWord = firstWord;
            LastWord = lastWord;
            WordsList = wordsList;
            SolverType = solverType;

            WordLadderParameters parameters = new WordLadderParameters(FirstWord, LastWord, WordsList);

            IWordLadderSolver solver = WordLadderSolverFactory.GetSolver(SolverType, parameters);
            WordLadderResult result = solver.SolveWordLadder();

            string joinedWords = string.Join(",", result.ResultSequence);

            return joinedWords;
        }
    }
}
