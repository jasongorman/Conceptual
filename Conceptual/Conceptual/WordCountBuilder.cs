using System;
using System.Collections.Generic;
using System.Linq;
using LemmaSharp.Classes;

namespace Conceptual
{
    public class WordCountBuilder
    {
        private readonly StopWordFilter _filter;
        private readonly Lemmatizer _lemmatizer;
        private readonly ISourceReader _sourceReader;

        public WordCountBuilder(StopWordFilter filter, Lemmatizer lemmatizer, ISourceReader sourceReader)
        {
            _filter = filter;
            _lemmatizer = lemmatizer;
            _sourceReader = sourceReader;
        }

        public Dictionary<string, int> GetWordCount(string sourceFilePath)
        {
            string[] codeTokens = _sourceReader.ReadTokens(sourceFilePath);
            return CountWords(GetWords(codeTokens));
        }

        private Dictionary<string, int> CountWords(string[] words)
        {
            return new WordCounter().Count(words);
        }

        private string[] GetWords(string[] requirementsTokens)
        {
            return _filter.Filter(requirementsTokens).Select(word => _lemmatizer.Lemmatize(word)).ToArray();
        }
    }
}