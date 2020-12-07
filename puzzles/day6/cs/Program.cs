using System.Linq;
using static System.IO.File;
using static System.Console;

var input = ReadAllText("puzzle.input");

WriteLine(input.Split("\n\n").Select(l => l.Replace("\n", "").ToHashSet()).Select(s => s.Count).Sum());

WriteLine(input.Split("\n\n").Select(l => l.Split('\n').Aggregate(l.AsEnumerable(), (a, b) => a.Intersect(b))).Select(s => s.Count()).Sum());
