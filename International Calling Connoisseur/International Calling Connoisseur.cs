using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>();
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        return new Dictionary<int, string>
        {
            { 1, "United States of America" },
            { 55, "Brazil" },
            { 91, "India" }
        };
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var dict = GetEmptyDictionary();
        dict.Add(countryCode, countryName);
        return dict;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.TryGetValue(countryCode, out string countryName))
        {
            return countryName;
        }
        return string.Empty;
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode))
        {
            existingDictionary[countryCode] = countryName;
        }
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longestName = string.Empty;
        foreach (var countryName in existingDictionary.Values)
        {
            if (countryName.Length > longestName.Length)
            {
                longestName = countryName;
            }
        }
        return longestName;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Tarea 1: GetEmptyDictionary ===");
        var emptyDict = DialingCodes.GetEmptyDictionary();
        Console.WriteLine($"Cantidad de elementos: {emptyDict.Count}");

        Console.WriteLine("\n=== Tarea 2: GetExistingDictionary ===");
        var existingDict = DialingCodes.GetExistingDictionary();
        PrintDictionary(existingDict);

        Console.WriteLine("\n=== Tarea 3: AddCountryToEmptyDictionary ===");
        var dictWithUK = DialingCodes.AddCountryToEmptyDictionary(44, "United Kingdom");
        PrintDictionary(dictWithUK);

        Console.WriteLine("\n=== Tarea 4: AddCountryToExistingDictionary ===");
        DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");
        PrintDictionary(existingDict);

        Console.WriteLine("\n=== Tarea 5: GetCountryNameFromDictionary ===");
        Console.WriteLine($"Código 55: '{DialingCodes.GetCountryNameFromDictionary(existingDict, 55)}'");
        Console.WriteLine($"Código 999: '{DialingCodes.GetCountryNameFromDictionary(existingDict, 999)}'");

        Console.WriteLine("\n=== Tarea 6: CheckCodeExists ===");
        Console.WriteLine($"¿Existe 55?: {DialingCodes.CheckCodeExists(existingDict, 55)}");
        Console.WriteLine($"¿Existe 999?: {DialingCodes.CheckCodeExists(existingDict, 999)}");

        Console.WriteLine("\n=== Tarea 7: UpdateDictionary ===");
        DialingCodes.UpdateDictionary(existingDict, 1, "Les États-Unis");
        DialingCodes.UpdateDictionary(existingDict, 999, "Newlands");
        PrintDictionary(existingDict);

        Console.WriteLine("\n=== Tarea 8: RemoveCountryFromDictionary ===");
        DialingCodes.RemoveCountryFromDictionary(existingDict, 91);
        PrintDictionary(existingDict);

        Console.WriteLine("\n=== Tarea 9: FindLongestCountryName ===");
        string longest = DialingCodes.FindLongestCountryName(existingDict);
        Console.WriteLine($"País con el nombre más largo: '{longest}'");
    }

    private static void PrintDictionary(Dictionary<int, string> dict)
    {
        foreach (var entry in dict)
        {
            Console.WriteLine($"  [{entry.Key}] => \"{entry.Value}\"");
        }
    }
}
