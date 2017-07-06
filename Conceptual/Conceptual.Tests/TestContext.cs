using System.IO;
using System.Reflection;

namespace Conceptual.Tests
{
    public class TestContext
    {
        private static readonly string _currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string CurrentDirectory
        {
            get { return _currentDirectory; }
        }
    }
}