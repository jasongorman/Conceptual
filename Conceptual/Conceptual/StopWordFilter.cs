using System.Linq;

namespace Conceptual
{
    public class StopWordFilter
    {
        private readonly string[] _stopWords;

        public StopWordFilter(string[] stopWords)
        {
            _stopWords = stopWords;
        }

        public string[] Filter(string[] words)
        {
            return words.Where(s => !_stopWords.Contains(s)).ToArray();
        }
    }
}