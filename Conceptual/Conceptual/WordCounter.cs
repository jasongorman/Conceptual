using System.Collections.Generic;

namespace Conceptual
{
    public class WordCounter
    {
        public Dictionary<string, int> Count(string[] tokens)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string token in tokens)
            {
                if (!wordCounts.ContainsKey(token))
                {
                    wordCounts.Add(token, 0);
                }
                wordCounts[token] += 1;
            }
            return wordCounts;
        }
    }
}