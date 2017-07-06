using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Foo
    {
        private string _field1;
        private string _field2;
        private const int _constant1 = 0;

        public void Bar1(int param1)
        {
            int variable1 = 0;
        }

        public string Property1 { get; set; }
    }

    public interface IFoo
    {
        void Bar2(int param2);
        int Property2 { get; set; }
    }

    public enum FooNum
    {
        Value1
    }
}
