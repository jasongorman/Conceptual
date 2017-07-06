using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LemmaSharp;
using LemmaSharp.Classes;

namespace Conceptual
{
    public class Application
    {
        private static StopWordFilter _filter;
        private static Lemmatizer _lemma;

        private static void Main(string[] args)
        {
            LoadStopWordFilter();
            LoadLemmatizer();

            WriteHeader();
            WriteDivider("-");

            var assemblyFile = args[0];
            var requirementsFile = args[1];

            var codeWordCount = GetWordCount(assemblyFile, new AssemblyReader());
            var requirementsWordCount = GetWordCount(requirementsFile, new TextFileReader());

            WriteWordCount(codeWordCount, "Code", assemblyFile);
            WriteDivider("-");
            WriteWordCount(requirementsWordCount, "Requirements", requirementsFile);
            WriteDivider("-");

            WriteCorrelation(codeWordCount, requirementsWordCount);

        }

        private static void WriteDivider(string repeatedString)
        {
            string divider = "";

            for (int i = 0; i < 50; i++)
            {
                divider += repeatedString;
            }

            Console.WriteLine(divider);
        }

        private static Dictionary<string, int> GetWordCount(string sourceFilePath, ISourceReader sourceReader)
        {
            return new WordCountBuilder(_filter, _lemma, sourceReader).GetWordCount(sourceFilePath);
        }

        private static void WriteCorrelation(Dictionary<string, int> codeWordCount, Dictionary<string, int> requirementsWordCount)
        {
            Console.WriteLine("Conceptual Correlation = {0:0.0}%",
                CalculateCorrelation(codeWordCount, requirementsWordCount)*100.0d);
        }

        private static double CalculateCorrelation(Dictionary<string, int> codeWordCount, Dictionary<string, int> requirementsWordCount)
        {
            return new CorrelationCalculator().Calculate(codeWordCount.Keys.ToArray(), requirementsWordCount.Keys.ToArray());
        }

        private static void WriteHeader()
        {
            Console.WriteLine("Conceptual Correlation Metric");
            Console.WriteLine("Written by Jason Gorman, Codemanship Ltd, www.codemanship.com (2017)");
            Console.WriteLine("PROOF OF CONCEPT. Provided with no warranty or support");
        }

        private static void WriteWordCount(Dictionary<string, int> wordCount, string wordType, string sourceFile)
        {
            Console.WriteLine("In " + sourceFile + ", " + wordCount.Count + " " + wordType + " Words found");
            var keys = wordCount.Keys;
            foreach (var word in keys.OrderBy(key => key).ToArray())
            {
                Console.WriteLine("..." + word + " (" + wordCount[word] + ")");
            }
        }

        private static void LoadStopWordFilter()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream stream = assembly.GetManifestResourceStream("Conceptual.stopwords_english.txt");
            StreamReader reader = new StreamReader(stream);
            List<string> stopwords = new List<string>();
            string stopword;
            while ((stopword = reader.ReadLine()) != null)
            {
                stopwords.Add(stopword);
            }
            _filter = new StopWordFilter(stopwords.ToArray());
        }

        private static void LoadLemmatizer()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var stream = File.OpenRead(path + @"\full7z-mlteast-en.lem");
            // terrible fudge to suppress unhandled deserialization exception message from LemmaSharp. 
            // Empty try..catch didn't work.
            TextWriter output = Console.Out;
            Console.SetOut(new StreamWriter(Stream.Null));
            _lemma = new Lemmatizer(stream);
            Console.SetOut(output);
 
        }
    }
}
