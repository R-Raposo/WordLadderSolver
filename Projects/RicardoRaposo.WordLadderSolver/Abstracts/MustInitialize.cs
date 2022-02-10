using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RRWLTester")]
namespace RicardoRaposo.DotNetWordLadderSolver.Abstracts
{
    internal abstract class MustInitialize<T>
    {
        public MustInitialize(T parameters)
        {

        }
    }
}
