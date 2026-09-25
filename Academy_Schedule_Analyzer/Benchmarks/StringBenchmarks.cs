using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class StringBenchmarks
{
    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    private const string Text = "x";

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";

        for (int i = 0; i < Iterations; i++)
        {
            result += Text;
        }

        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < Iterations; i++)
        {
            result.Append(Text);
        }

        return result.ToString();
    }
}
