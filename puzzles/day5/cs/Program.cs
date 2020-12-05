using System;
using System.Linq;
using static System.IO.File;
using static System.Console;

var seatsFound = 
    ReadAllLines("puzzle.input")
    .Select(Id)
    .OrderBy(i => i)
    .ToArray();

var lastFound = seatsFound[0];
for (int i = 1; i < seatsFound.Length; i++)
{
    if (seatsFound[i] == lastFound + 2)
        WriteLine(seatsFound[i] - 1);
    lastFound = seatsFound[i];
}

int Id(string path) => Traverse(path[..^3]) * 8 + Traverse(path[^3..]);

int Traverse(string path) => Convert.ToInt32(path.Replace("R", "1").Replace("B", "1").Replace("L", "0").Replace("F", "0"), 2);

