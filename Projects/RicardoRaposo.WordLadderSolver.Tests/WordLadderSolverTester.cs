using Microsoft.VisualStudio.TestTools.UnitTesting;
using RicardoRaposo.DotNetWordLadderSolver;
using RicardoRaposo.DotNetWordLadderSolver.Enums;
using RicardoRaposo.DotNetWordLadderSolver.Implementations.BADS;
using RicardoRaposo.DotNetWordLadderSolver.WordLadderInputParameters;
using System;
using System.IO;

namespace RRWLTester
{
    [TestClass]
    public class WordLadderSolverTester
    {
        [TestMethod]
        public void TestClassInstanceConstructor_NullParameters()
        {
            bool exceptionOcurred = false;
            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder(null, null, null);
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            Assert.IsTrue(exceptionOcurred);
        }

        [TestMethod]
        public void TestClassInstanceConstructor_2LastParametersNull()
        {
            bool exceptionOcurred = false;
            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder("Boat", null, null);
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }
            
            Assert.IsTrue(exceptionOcurred);
        }

        [TestMethod]
        public void TestClassInstanceConstructor_NoWordDictionary()
        {
            bool exceptionOcurred = false;
            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder("Boat", "Ride", null);
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            // This test will fail at this moment, the constructor accepts the 'wordsList' array to be null.
            // So, no exception will occur, and thus the test assertion will fail
            Assert.IsTrue(exceptionOcurred);
        }

        [TestMethod]
        public void TestClassInstanceConstructor_NoWordDictionary_AndTryToSolveLadder()
        {
            bool exceptionOcurred = false;
            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder("Boat", "Ride", null);
                string solution = solver.GetSolution();
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            // This test will succeed, the constructor works with no 'wordsList' array, but when we try to run the instance 'GetSolution()' method, an exception occurs
            Assert.IsTrue(exceptionOcurred);
        }

        [TestMethod]
        public void TestClassInstanceConstructor_NormalUseCase_2WordsList()
        {
            bool exceptionOcurred = false;
            string solution = null;
            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder("boat", "boot", new string[] { "boat", "boot" });
                solution = solver.GetSolution();
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            Assert.IsTrue(exceptionOcurred == false);
            Assert.IsTrue(string.IsNullOrWhiteSpace(solution) == false);
        }

        [TestMethod]
        public void TestClassInstanceConstructor_NormalUseCase_3WordsList()
        {
            bool exceptionOcurred = false;
            string solution = null;
            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder("boat", "bool", new string[]{"boat", "boot", "bool"});
                solution = solver.GetSolution();
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            Assert.IsTrue(exceptionOcurred == false);
            Assert.IsTrue(string.IsNullOrWhiteSpace(solution) == false);
        }


        [TestMethod]
        public void TestClassInstanceConstructor_NormalUseCase_LotsOfWords()
        {
            bool exceptionOcurred = false;
            string solution = null;

            string[] wordsList = GetWordListFromFile();

            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder("carp", "road", wordsList);
                solution = solver.GetSolution();
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            Assert.IsTrue(exceptionOcurred == false);
            Assert.IsTrue(string.IsNullOrWhiteSpace(solution) == false);
        }

        [TestMethod]
        public void TestClassInstanceConstructor_NormalUseCase_LotsOfWords2()
        {
            bool exceptionOcurred = false;
            string solution = null;

            string[] wordsList = GetWordListFromFile();

            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder("boat", "carp", wordsList);
                solution = solver.GetSolution();
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            Assert.IsTrue(exceptionOcurred == false);
            Assert.IsTrue(string.IsNullOrWhiteSpace(solution) == false);
        }

        [TestMethod]
        public void TestClassInstanceConstructor_NoPossibleSolutionUseCase()
        {
            bool exceptionOcurred = false;
            string solution = null;
            try
            {
                WordLadderSolutionBuilder solver = new WordLadderSolutionBuilder("boat", "bool", new string[] { "boat", "ball", "bait", "bail", "bool" });
                solution = solver.GetSolution();
            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            Assert.IsTrue(exceptionOcurred == false);
            Assert.IsTrue(string.IsNullOrWhiteSpace(solution)); // no solution to this wordLadder, so the test is a success if the solution string is empty
        }


        [TestMethod]
        public void TestInternalBADSClass()
        {
            bool exceptionOcurred = false;
            string solution = null;
            try
            {
                WordLadderParameters parameters = new WordLadderParameters("Bone", "Tail", new string[] { "boat", "ball", "bait", "bail", "bool" });
                BreadthAndDepthSearchSolver BADSBuilder = new BreadthAndDepthSearchSolver(parameters);

            }
            catch (System.Exception)
            {
                exceptionOcurred = true;
            }

            Assert.IsTrue(exceptionOcurred == false);
            Assert.IsTrue(string.IsNullOrWhiteSpace(solution)); // no solution to this wordLadder, so the test is a success if the solution string is empty
        }

        [TestMethod]
        public void TestStaticClassUsage()
        {
            string[] wordsList = GetWordListFromFile();

            string solution = WordLadderSolutionBuilder.GetSolution("Loop", "Goal", wordsList, WordLadderSolverType.BADS);

            Assert.IsTrue(solution == "loop,coop,cool,coal,goal");
        }

        #region Helper methods
        private static string[] GetWordListFromFile()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string filePath = Path.Combine(Directory.GetParent(workingDirectory).Parent.Parent.FullName, "Dictionary/words-english.txt");

            using StreamReader reader = File.OpenText(filePath);
            var fileText = reader.ReadToEnd();

            string[] wordsList;

            if (string.IsNullOrWhiteSpace(fileText))
            {
                //File empty?
                wordsList = new string[0];
            }
            else
            {
                wordsList = fileText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            }

            return wordsList;
        }
        #endregion
    }
}
