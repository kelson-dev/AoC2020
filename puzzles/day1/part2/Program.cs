using static System.Console;
using System.Collections.Generic;

var numbers = new List<int>(2000);
var solutions = new Dictionary<int, (int, int)>();

while (int.TryParse(ReadLine().Trim(), out int number))
{
    if (solutions.TryGetValue(number, out (int a, int b) pair))
    {
        WriteLine(number * pair.a * pair.b);
        return;
    }

    foreach (var existing in numbers)
        if (existing + number < 2020)
            solutions.TryAdd(2020 - existing - number, (existing, number));
    numbers.Add(number);
}
