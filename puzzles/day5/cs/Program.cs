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

int Id(string path)
{
    var (row, _) = Traverse(0, 127, path[..^3]);
    var (column, _) = Traverse(0, 7, path[^3..]);
    return (row * 8 + column);
}

(int, int) Traverse(int rmin, int rmax, string path)
{
    path = path.Replace("R", "B").Replace("L", "F");
    foreach (var c in path)
    {
        var dif = (rmax - rmin) / 2;
        if (c == 'F')
            rmax = rmax - dif - 1;
        else if (c == 'B')
            rmin = rmin + dif + 1;
    }
    return (rmin, rmax);
}

