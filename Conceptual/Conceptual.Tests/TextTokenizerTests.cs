using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Conceptual.Tests
{
    [TestFixture]
    public class TextTokenizerTests
    {
        [TestCase("", new string[]{})]
        [TestCase("Foo", new string[]{"foo"})]
        [TestCase("The lazy fox", new string[]{"the", "lazy", "fox"})]
        [TestCase("One, two. Three. 79!", new string[] {"one", "two", "three" })]
        public void TextIsTokenizedToOnlyIncludeWords(string text, string[] expectedTokens)
        {
            string[] tokens = new Tokenizer(TextFileReader.PlainTextRegex, false).Tokenize(text);
            Assert.That(tokens, Is.EqualTo(expectedTokens));
        }
    }
}
