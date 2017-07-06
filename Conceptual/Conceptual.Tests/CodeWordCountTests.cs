using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Conceptual.Tests
{
    [TestFixture]
    public class CodeWordCountTests
    {
        [Test]
        public void BuildWordCountOfTestDll()
        {
            string[] codeNames = new CodeNameLister(TestContext.CurrentDirectory + @"\Test.dll").List();
            string[] allTokens = {};
            Tokenizer tokenizer = new Tokenizer(@"(^(^[a-z]+)|([0-9]+)|([A-Z]{1}[a-z]+)|([A-Z]+(?=([A-Z][a-z])|($)|([0-9])))$)", false);
            allTokens = codeNames.Aggregate(allTokens, (current, name) => current.Concat(tokenizer.Tokenize(name)).ToArray());
            Dictionary<string, int> wordCount = new WordCounter().Count(allTokens);
            Assert.That(wordCount, Has.Count.GreaterThan(0));
        }
    }
}
