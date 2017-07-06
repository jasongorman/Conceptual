namespace Conceptual
{
    public interface ISourceReader
    {
        string[] ReadTokens(string assemblyFilePath);
    }
}