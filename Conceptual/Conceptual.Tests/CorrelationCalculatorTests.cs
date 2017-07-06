using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Conceptual.Tests
{
    [TestFixture]
    public class CorrelationCalculatorTests
    {
        [TestCase(new string[] { "foo" }, new string[] { "bar" }, 0)]
        [TestCase(new string[] { "foo" }, new string[] { "foo" }, 1)]
        [TestCase(new string[] { "foo", "bar" }, new string[] { "foo", "fum" }, 0.5)]
        public void CorrelationIsFractionOfCodeWordsContainedInRequirements(string[] codeWords, string[] requirementsWords, double expected)
        {
            double correlation = new CorrelationCalculator().Calculate(codeWords, requirementsWords);
            Assert.That(correlation, Is.EqualTo(expected));
        }

    }
}
