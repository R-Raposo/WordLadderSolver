using System.Collections.Generic;
using RicardoRaposo.DotNetWordLadderSolver.Interfaces;
using RicardoRaposo.DotNetWordLadderSolver.Abstracts;
using System.Runtime.CompilerServices;
using RicardoRaposo.DotNetWordLadderSolver.WordLadderInputParameters;

[assembly: InternalsVisibleTo("RRWLTester")]
namespace RicardoRaposo.DotNetWordLadderSolver.Implementations.BADS
{
    /// <summary>
    /// Class that uses a 'Breadth First Search and Depth First Search' solver to the WordLadder game
    /// </summary>
    internal class BreadthAndDepthSearchSolver : MustInitialize<WordLadderParameters>, IWordLadderSolver
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        /// <summary>
        /// Maps each word, with other similar words that exist in the word list, that have only one letter of difference
        /// </summary>
        private readonly Dictionary<string, List<string>> Mapping;
        public string FirstWord { get; set; }
        public string LastWord { get; set; }
        public string[] WordDictionary { get; set; }

        /// <summary>
        /// This constructor requires the <paramref name="wlParameters"/> parameter
        /// </summary>
        /// <param name="wlParameters">Input parameters required to play the Word Ladder game</param>
        public BreadthAndDepthSearchSolver(WordLadderParameters wlParameters) : base(wlParameters)
        {
            // This class implements the 'MustInitialize' abstract class, that forces this constructor with a 'WordLadderParameters' object parameter.
            // Using this constructor helps make sure all the properties we need are filled
            // for no other reason in particular, but may be useful in the future

            FirstWord = wlParameters.FirstWord;
            LastWord = wlParameters.LastWord;
            WordDictionary = wlParameters.WordDictionary;

            Mapping = new Dictionary<string, List<string>>();
        }

        public WordLadderResult SolveWordLadder()
        {
            List<List<string>> endResult = new List<List<string>>();

            HashSet<string> firstWordSet = new HashSet<string>
            {
                FirstWord
            };

            HashSet<string> wordDictionarySet = new HashSet<string>(WordDictionary);

            BreadthFirstSearch(firstWordSet, LastWord, wordDictionarySet, Mapping);

            List<string> listWithFirstWord = new List<string>
            {
                FirstWord
            };

            DepthFirstSearch(endResult, listWithFirstWord, FirstWord, LastWord, Mapping);

            WordLadderResult resultToReturn = new BreadthAndDepthSearchResult(endResult);

            return resultToReturn;
        }

        private void BreadthFirstSearch(HashSet<string> startingSet, string lastWord, HashSet<string> wordDictionarySet, Dictionary<string, List<string>> mapping)
        {
            if(startingSet.Count == 0)
            {
                return; // no words to loop through, exit method
            }

            HashSet<string> foundWords = new HashSet<string>();
            wordDictionarySet.ExceptWith(startingSet); // Removes the 'startingSet' from the word list.
                                                       // We remove the found words from the word list, so that we do not loop unnecessarily
                                                       // In the first iteration, the 'startingSet' will consist of only one word, the start word.
                                                       // In the next iterations, it will consist of all words that were found through changing one word at a time from the original first word, and it's similars.

            bool finished = false;

            foreach (string word in startingSet)
            {
                char[] wordArr = word.ToCharArray();
                for (int i = 0; i < wordArr.Length; i++) // Loop foreach char in current word
                {
                    char oldChar = wordArr[i]; // save the current char

                    for (int j = 0; j < Alphabet.Length; j++) // Loop foreach letter in the alphabet
                    {
                        wordArr[i] = Alphabet[j]; // change the current char being looped, with the current letter of the alphabet being looped
                        string createdWord = new string(wordArr); // create a string with the new word

                        if(wordDictionarySet.Contains(createdWord)) // check if the word list contains this newly created word
                        {
                            // word exists in the word list
                            if(createdWord == lastWord) // check if this created word is the last word
                            {
                                finished = true; // mark as finished
                            }
                            else
                            {
                                foundWords.Add(createdWord); // this word is not the last word, save it anyways on the HashSet
                            }

                            if(mapping.ContainsKey(word) == false)
                            {
                                mapping.Add(word, new List<string>()); // add an entry for the word from the looped set, to a dictionary that saves connections between words
                            }

                            mapping[word].Add(createdWord); // create a mapping between the word from the looped set, and the newly created word
                        }
                    }

                    wordArr[i] = oldChar; // put back the original char that was being looped through and changed with all the alphabet words
                }
            }
            if(finished == false) // in case the search is not finished, we will loop again through all the newly found words, and do the same cycles for each word found
            {
                BreadthFirstSearch(foundWords, lastWord, wordDictionarySet, mapping);
            }
        }

        private void DepthFirstSearch(List<List<string>> result, List<string> list, string word, string endWord, Dictionary<string, List<string>> mapping)
        {
            if(word == endWord) // word being looped is the last word, so we have reached the end of the sequence
            {
                result.Add(new List<string>(list)); // solution has been reached, save it to the list of solutions, and break current function call
                return;
            }

            if(mapping.ContainsKey(word) == false) // the mapping dictionary does not contain the current word, break current function call
            {
                return;
            }

            foreach (string mappedWord in mapping[word]) // loop through every word, that is connected to the current word being looped
            {
                list.Add(mappedWord); // add the current connected word to the sequence list
                DepthFirstSearch(result, list, mappedWord, endWord, mapping); // recursively call the function, for the current connected word, to loop through the current connected word's connected words
                list.RemoveAt(list.Count - 1); // remove the current connected word from the sequence list
            }
        }
    }
}
