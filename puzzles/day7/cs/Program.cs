using System.Collections.Generic;
using static System.Console;
using static System.IO.File;
using System.Linq;
using System;

var graph = ReadAllLines("puzzle.input")
    .Select(SplitOnContains)
    .Select(ColorToContained)
    .ToDictionary(
        c => c.color, 
        c => c.contained.ToDictionary(r => r.bag, r => r.count));

WriteLine("Number of bags that can contain shiny gold bags:");
WriteLine(graph.Keys.Where(key => CanContainShinyGold(key)).Count());
WriteLine("Number of bags that must be contained by shiny gold bags:");
WriteLine(CountContainedBags("shiny gold"));

bool CanContainShinyGold(string color, HashSet<string> traversed = null) =>
    (traversed ??= new()).Add(color)
    && (graph[color].ContainsKey("shiny gold")
        || graph[color]
            .Where(kvp => !traversed.Contains(kvp.Key))
            .Where(kvp => CanContainShinyGold(kvp.Key, traversed))
            .Any());

int CountContainedBags(string color, Dictionary<string, int> found = null) =>
    (found ??= new()).TryGetValue(color, out int result)
        ? result
        : (found[color] = graph[color].Select(bc => bc.Value + bc.Value * CountContainedBags(bc.Key, found)).Sum());


#region Parsing 🙃
(string color, (int count, string bag)[] contained) ColorToContained(string[] r) =>
    r[1] == "no other bags"
        ? (r[0], Array.Empty<(int count, string bag)>())
        : (r[0].Trim(), CountsOfBags(r[1]));

string[] SplitOnContains(string line) => line[..^1].Split("bags contain", StringSplitOptions.TrimEntries);

(int count, string bag) CountOfBag(string c) => (int.Parse(c[..1]), c[2..]);

(int count, string bag)[] CountsOfBags(string contains) => contains.Split(',').Select(TrimRule).Select(CountOfBag).ToArray();

string TrimRule(string c) => c.Replace(".", "").Replace("bags", "").Replace("bag", "").Trim();
#endregion

