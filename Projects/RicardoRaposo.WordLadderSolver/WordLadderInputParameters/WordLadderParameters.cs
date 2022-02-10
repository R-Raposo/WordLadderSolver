using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RRWLTester")]
namespace RicardoRaposo.DotNetWordLadderSolver.WordLadderInputParameters
{
    /// <summary>
    /// Class with the parameters needed to play the Word Ladder game
    /// </summary>
    internal class WordLadderParameters
    {
        public string FirstWord, LastWord;
        public string[] WordDictionary;

        public WordLadderParameters(string firstWord, string lastWord, string[] wordDictionary)
        {
            FirstWord = firstWord;
            LastWord = lastWord;
            WordDictionary = wordDictionary;
        }
    }
}
