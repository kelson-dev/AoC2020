using static System.IO.File;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

var required = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
var validEyeColors = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

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
        .Where(IsValidPassport)
        .Count());

bool IsValidPassport(Dictionary<string, string> passport) => 
       required.All(key => passport.ContainsKey(key))
    && int.TryParse(passport["byr"], out int byr) && (byr >= 1920 && byr <= 2002)
    && int.TryParse(passport["iyr"], out int iyr) && (iyr >= 2010 && iyr <= 2020)
    && int.TryParse(passport["eyr"], out int eyr) && (eyr >= 2020 && eyr <= 2030)
    && IsValidHeight(passport["hgt"])
    && IsValidColor(passport["hcl"])
    && validEyeColors.Contains(passport["ecl"])
    && passport["pid"].Length == 9 && passport["pid"].All(char.IsDigit);

bool IsValidHeight(string hgt)
{
    if (hgt.EndsWith("cm"))
        return int.TryParse(hgt[..^2], out int hgtCm) && hgtCm >= 150 && hgtCm <= 193;
    else if (hgt.EndsWith("in"))
        return int.TryParse(hgt[..^2], out int hgtIn) && hgtIn >= 59 && hgtIn <= 76;
    else
        return false;
}

bool IsValidColor(string color) =>
       color.Length == 7
    && color.StartsWith("#")
    && color[1..].All(c => char.IsDigit(c) || (c >= 'a' && c <= 'f'));