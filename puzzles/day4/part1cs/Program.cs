using static System.IO.File;
using static System.Console;
using System.Linq;

var required = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

WriteLine(
    ReadAllText("puzzle.input")
        .Replace("\n", "♥")
        .Replace("♥♥", "\n")
        .Replace("♥", " ")
        .Split("\n")
        .Select(passport => 
            passport.Trim()
                .Split(' ')
                .Select(kvp => kvp.Split(':'))
                .ToDictionary(kvp => kvp[0], kvp => kvp[1]))
        .Where(passport => required.All(key => passport.ContainsKey(key)))
        .Count());
