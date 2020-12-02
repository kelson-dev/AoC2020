using static System.Console;
using System;
using static System.IO.File;

var lines = ReadAllLines("puzzle.input");

var valid = 0;
foreach (var line in lines)
{
    var span = line.AsSpan();
    valid += new Policy(ref span).Evaluate(span) ? 1 : 0;
}

WriteLine(valid);

public readonly ref struct Policy
{
    public readonly int First;
    public readonly int Second;
    public readonly char Letter;

    public Policy(ref ReadOnlySpan<char> source)
    {
        var (dash, space) = (source.IndexOf('-'), source.IndexOf(' '));
        var first = source[..dash++];
        var second = source[dash..space++];

        First = int.Parse(first);
        Second = int.Parse(second);
        Letter = source[space];
        source = source[(first.Length + second.Length + 5)..];
    }

    public bool Evaluate(ReadOnlySpan<char> pass) => 
           (pass[First - 1] == Letter && pass[Second - 1] != Letter)
        || (pass[First - 1] != Letter && pass[Second - 1] == Letter);
}
