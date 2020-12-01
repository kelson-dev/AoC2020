using static System.Console;
using System.Collections.Generic;
using System.Linq;

var numbers = new SortedSet<int>();

string line = "";
while ((line = ReadLine()?.Trim()) != "END")
    if (int.TryParse(line, out int number))
        numbers.Add(number);

while (numbers.Count > 0)
{
    var first = numbers.Max;
    foreach (var second in numbers)
    {
        if (second == first)
            continue;
        var third = 2020 - first - second;
        if (third == first || third == second)
            continue;
        if (third < numbers.Min)
            continue;
        if (numbers.Contains(third)) 
        {
            WriteLine($"{first} * {second} * {third}");
            WriteLine(first * second * third);
            return;
        }
    }
    numbers.Remove(first);
}
