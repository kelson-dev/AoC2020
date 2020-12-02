using static System.Console;
using System.Collections.Generic;

var numbers = new HashSet<int>();

string line = "";
while ((line = ReadLine().Trim()) != "")
{
    if (int.TryParse(line, out int number))
    {
        var dif = 2020 - number;
        if (numbers.Contains(dif))
        {
            WriteLine(dif * number);
            return; 
        }
        else
        {
            numbers.Add(number);
        }
    }
}