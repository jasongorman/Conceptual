using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Conceptual.Tests
{
    [TestFixture]
    public class CodeNameTokenizerTests
    {
        [TestCase("Foo", new string[]{"foo"})]
        [TestCase("foo", new string[] { "foo" })]
        [TestCase("FooBar", new string[] { "foo", "bar"})]
        [TestCase("fooBar", new string[] { "foo", "bar"})]
        [TestCase("fooBarFum", new string[] { "foo", "bar", "fum"})]
        [TestCase("FOO", new string[] { "foo" })]
        [TestCase("FOOBarFum", new string[] { "foo", "bar", "fum"})]
        [TestCase("foo99", new string[] { "foo"})] // ignores numbers
        [TestCase("Foo99MVCBar7", new string[] { "foo", "mvc", "bar"})]
        public void AlphanumericPascalCaseAndCamelCaseNamesAreTokenized(string name, string[] expectedTokens)
        {
            string[] tokens = new Tokenizer(AssemblyReader.PascalCamelCaseRegex, true).Tokenize(name);
            Assert.That(tokens, Is.EqualTo(expectedTokens));
        }

    }
}
