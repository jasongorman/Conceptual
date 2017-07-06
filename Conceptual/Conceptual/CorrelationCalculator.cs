using System.Linq;

namespace Conceptual
{
    public class CorrelationCalculator
    {
        public double Calculate(string[] codeWords, string[] requirementsWords)
        {
            return (double)codeWords.Count(requirementsWords.Contains)/codeWords.Length;
        }
    }
}