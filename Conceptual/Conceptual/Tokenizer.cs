using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Conceptual
{
    public class Tokenizer
    {
        private readonly bool _distinct;
        private readonly Regex _regex;

        public Tokenizer(string regex, bool distinct)
        {
            _distinct = distinct;
            _regex = new Regex(regex);
        }

        public string[] Tokenize(string text)
        {
            var tokens = _regex.Split(text, text.Length)
                .Where(s => s.Length > 0 && s.All(char.IsLetter))
                .Select(s => s.ToLower());
            if (_distinct)
            {
                tokens = tokens.Distinct();
            }
            return tokens.ToArray();
        }
    }
}