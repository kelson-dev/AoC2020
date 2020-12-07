using System.Linq;
using static System.IO.File;
using static System.Console;

var input = ReadAllText("puzzle.input").Split("\n\n");

WriteLine(input.Select(l => l.Replace("\n", "").Distinct()).Select(s => s.Count()).Sum());

WriteLine(input.Select(l => l.Split('\n').Aggregate(l.AsEnumerable(), (a, b) => a.Intersect(b))).Select(s => s.Count()).Sum());