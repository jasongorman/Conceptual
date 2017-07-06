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
    public class TextFileReaderTests
    {
        [Test]
        public void ReadsTextFromFile()
        {
            string fileName = TestContext.CurrentDirectory + @"\testtext.txt";
            string[] text = new TextFileReader().ReadTokens(fileName);
            Assert.That(text, Is.EqualTo(new string[]{"test", "text"}));
        }
    }
}
