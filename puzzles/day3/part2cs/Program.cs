using System;
using static System.Console;
using System.IO;
using System.Linq;

const char tree = '#';

(int, int)[] dirs = new []
{ 
    (1, 1),
    (3, 1),
    (5, 1),
    (7, 1),
    (1, 2)
};

int width = 31;

var map = File.ReadAllLines("puzzle.input");

var treesOnEach = dirs
    .Select(TreesOnRoute)
    .Aggregate(1L, (a, t) => a * t);

WriteLine(treesOnEach);

long TreesOnRoute((int, int) direction)
{
    var (dc, dr) = direction;
    var (column, row) = (0, 0);
    long trees = 0;

    while (row < map.Length)
    {
        var line = map[row];
        if (line[column % width] == tree)
            trees++;
        (column, row) = (column + dc, row + dr);
    }
    return trees;
}