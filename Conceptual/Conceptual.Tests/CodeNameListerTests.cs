using System;
using System.Collections;
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
    public class CodeNameListerTests
    {
        private readonly static string _assembly 
            = TestContext.CurrentDirectory + @"\Test.dll";

        private readonly static string[] _names;

        static CodeNameListerTests()
        {
            _names = new CodeNameLister(_assembly).List();
        }

        [Test]
        public void FindsTypeNames()
        {
            CollectionAssert.Contains(_names, "Foo");
            CollectionAssert.Contains(_names, "IFoo");
            CollectionAssert.Contains(_names, "FooNum");
        }

        [Test]
        public void FindsMethodNames()
        {
            CollectionAssert.Contains(_names, "Bar1");
            CollectionAssert.Contains(_names, "Bar2");
        }

        [Test]
        public void FindsFieldNames()
        {
            CollectionAssert.Contains(_names, "_field1");
            CollectionAssert.Contains(_names, "_field2");
        }

        [Test]
        public void FindsParameterNames()
        {
            CollectionAssert.Contains(_names, "param1");
            CollectionAssert.Contains(_names, "param2");
        }

        [Test]
        public void FindsPropertyNames()
        {
            CollectionAssert.Contains(_names, "Property1");
            CollectionAssert.Contains(_names, "Property2");
        }

        [Test]
        public void FindsConstantNames()
        {
            CollectionAssert.Contains(_names, "_constant1");
        }

        [Test]
        public void FindsEnumValueNames()
        {
            CollectionAssert.Contains(_names, "Value1");
        }

        [Test]
        public void FindsVariableNames()
        {
            CollectionAssert.Contains(_names, "variable1");
        }
    }
}
