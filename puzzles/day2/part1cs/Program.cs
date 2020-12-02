using static System.Console;
using System;
using System.IO;

var valid = 0;
using var stream = File.OpenRead("puzzle.input");
using var reader = new StreamReader(stream);
unsafe
{
    Span<char> buffer = stackalloc char[32];

    int read = -1;
    int offset = 0;
    var range = buffer[offset..];
    while ((read = reader.Read(range)) > 0)
    {
        var line = buffer[..buffer.IndexOf('\n')];
        var length = line.Length + 1;
        valid += new Policy(ref line).Evaluate(line) ? 1 : 0;
        var remaining = buffer[length..];
        remaining.CopyTo(buffer);
        range = buffer[remaining.Length..];
    }
}

WriteLine(valid);

public readonly ref struct Policy
{
    public readonly int Min;
    public readonly int Max;
    public readonly char Letter;

    public Policy(ref Span<char> source)
    {
        var (dash, space) = (source.IndexOf('-'), source.IndexOf(' '));
        var first = source[..dash++];
        var second = source[dash..space++];
        Min = ParseInt(first);
        Max = ParseInt(second);
        Letter = source[space];
        source = source[(first.Length + second.Length + 5)..];
    }

    public bool Evaluate(Span<char> pass)
    {
        int count = 0;
        foreach (var character in pass)
            if (character == Letter)
                count++;
        return count >= Min && count <= Max;
    }

    static int ParseInt(Span<char> text)
    {
        int sum = 0;
        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (c < '0' || c > '9')
                return sum;
            sum += (text[i] - '0');
        }
        return sum;
    }
}
