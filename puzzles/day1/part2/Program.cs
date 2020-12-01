using static System.Console;
using System.Collections.Generic;

var numbers = new HashSet<int>();
var solutions = new Dictionary<int, (int, int)>();

string line = "";
while ((line = ReadLine()?.Trim()) != "END")
{
    if (int.TryParse(line, out int number))
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
}
