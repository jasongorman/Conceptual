using System.Linq;

namespace Conceptual
{
    public class AssemblyReader : ISourceReader
    {
        public const string PascalCamelCaseRegex 
                        = @"(^(^[a-z]+)|([0-9]+)|([A-Z]{1}[a-z]+)|([A-Z]+(?=([A-Z][a-z])|($)|([0-9])))$)";

        private readonly Tokenizer _tokenizer = new Tokenizer(PascalCamelCaseRegex, true);

        public string[] ReadTokens(string assemblyFilePath)
        {
            string[] codeNames = new CodeNameLister(assemblyFilePath).List();
            return codeNames.SelectMany(
                    s => _tokenizer.Tokenize(s)).ToArray();
        }
    }
}