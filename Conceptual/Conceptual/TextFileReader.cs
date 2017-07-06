using System.IO;

namespace Conceptual
{
    public class TextFileReader : ISourceReader
    {
        public const string PlainTextRegex = @"\W+";

        private Tokenizer _tokenizer = new Tokenizer(PlainTextRegex, false);

        public string[] ReadTokens(string fileName)
        {
            return _tokenizer.Tokenize(File.ReadAllText(fileName));
        }
    }
}