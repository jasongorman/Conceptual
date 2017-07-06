using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Conceptual.Tests
{
    [TestFixture]
    public class StopWordFilterTests
    {
        [Test]
        public void RemovesStopWordsFromArray()
        {
            string[] stopWords = {"fum", "fee"};
            string[] filtered = new StopWordFilter(stopWords).Filter(new string[]{"foo", "bar", "fum", "fee"});
            Assert.That(filtered, Is.EqualTo(new string[]{"foo", "bar"}));
        }
    }
}
