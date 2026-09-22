using System;
using System.Collections.Generic;

public static class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string> { "C#", "Clojure", "Elm" };
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        if (languages.Count == 0)
        {
            return false;
        }

        if (languages[0] == "C#")
        {
            return true;
        }

        if (languages.Count >= 2 && languages.Count <= 3 && languages[1] == "C#")
        {
            return true;
        }

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        var uniqueLanguages = new HashSet<string>(languages);
        return uniqueLanguages.Count == languages.Count;
    }
}

class Program
{
    static void Main()
    {
        List<string> vacia = Languages.NewList();
        Console.WriteLine($"1. Lista vacía creada. Conteo: {vacia.Count}");

        List<string> misLenguajes = Languages.GetExistingLanguages();
        Console.WriteLine($"2. Lista inicial: {string.Join(", ", misLenguajes)}");

        Languages.AddLanguage(misLenguajes, "VBA");
        Console.WriteLine($"3. Tras agregar VBA: {string.Join(", ", misLenguajes)}");

        int total = Languages.CountLanguages(misLenguajes);
        Console.WriteLine($"4. Total de lenguajes: {total}");

        bool tieneElm = Languages.HasLanguage(misLenguajes, "Elm");
        Console.WriteLine($"5. ¿Contiene 'Elm'?: {tieneElm}");
       
        List<string> Reves = Languages.ReverseList(misLenguajes);
        Console.WriteLine($"6. Lista invertida: {string.Join(", ", Reves)}");

        List<string> listaEjemplo = Languages.GetExistingLanguages(); // {"C#", "Clojure", "Elm"}
        bool esEmocionante = Languages.IsExciting(listaEjemplo);
        Console.WriteLine($"7. ¿Es emocionante?: {esEmocionante}");

        Languages.RemoveLanguage(misLenguajes, "Clojure");
        Console.WriteLine($"8. Tras eliminar Clojure: {string.Join(", ", misLenguajes)}");

        bool esUnica = Languages.IsUnique(misLenguajes);
        Console.WriteLine($"9. ¿Son únicos los elementos?: {esUnica}");

        List<string> duplicados = new List<string> { "C#", "Java", "C#" };
        Console.WriteLine($"9b. ¿Son únicos {string.Join(", ", duplicados)}?: {Languages.IsUnique(duplicados)}");
    }
}
