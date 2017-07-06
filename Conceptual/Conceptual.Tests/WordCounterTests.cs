using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Conceptual.Tests
{
    [TestFixture]
    public class WordCounterTests
    {
        private readonly WordCounter _wordCounter;

        public WordCounterTests()
        {
            _wordCounter = new WordCounter();
        }

        [Test]
        public void EmptyTokenArrayGivesEmptyWordCount()
        {
            Assert.That(_wordCounter.Count(new string[]{}), 
                            Is.EqualTo(new Dictionary<string, int>{}));
        }

        [Test]
        public void SingleTokenHasWordCountOfOne()
        {
            Assert.That(_wordCounter.Count(new string[] {"foo" }), 
                            Is.EqualTo(new Dictionary<string, int> { {"foo", 1}}));
        }

        [Test]
        public void RepeatedTokenHasWordCountOfTwo()
        {
            Assert.That(_wordCounter.Count(new string[] { "foo", "foo" }), 
                            Is.EqualTo(new Dictionary<string, int> { { "foo", 2 } }));
        }

        [Test]
        public void MultipleDifferentTokensHaveCorrectWordCount()
        {
            Assert.That(_wordCounter.Count(new string[] { "foo", "foo", "bar", "fum", "fum", "fum" }), 
                            Is.EqualTo(new Dictionary<string, int> { { "foo", 2 }, {"bar", 1}, {"fum", 3} }));
        }
    }
}
