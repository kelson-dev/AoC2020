using System;
using static System.Console;
using System.IO;
using System.Linq;

const char tree = '#';

int width = 31;

var map = File.ReadAllLines("puzzle.input");

var column = 0;
var dc = 3;
int trees = 0;

for (int row = 0; row < map.Length; row++)
{
    var line = map[row];
    if (line[column % width] == tree)
        trees++;
    column = column + dc;
}



WriteLine(trees);