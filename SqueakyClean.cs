using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < identifier.Length; i++)
        {
            char ch = identifier[i];

            // Tarea 1: Reemplazar espacios por guiones bajos
            if (ch == ' ')
            {
                sb.Append('_');
            }
            // Tarea 2: Reemplazar caracteres de control por "CTRL"
            else if (char.IsControl(ch))
            {
                sb.Append("CTRL");
            }
            // Tarea 3: Convertir kebab-case a camelCase (reemplazar guión y volver mayúscula el siguiente carácter)
            else if (ch == '-')
            {
                if (i + 1 < identifier.Length && char.IsLetter(identifier[i + 1]))
                {
                    sb.Append(char.ToUpper(identifier[i + 1]));
                    i++; 
                }
            }
            else if (ch >= 'α' && ch <= 'ω')
            {
                continue; 
            }
            else if (char.IsLetter(ch) || ch == '_')
            {
                sb.Append(ch);
            }
        }

        return sb.ToString();
    }

    class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("     LIMPIADOR DE IDENTIFICADORES (C#)        ");

        // Casos de prueba requeridos por el ejercicio:
        string[] pruebas = {
            "my   Id",          
            "my\0Id",           
            "à-ḃç",             
            "1😀2😀3😀",        
            "MyΟβιεγτFinder"    
        };

        for (int i = 0; i < pruebas.Length; i++)
        {
            string entrada = pruebas[i];
            string salida = Identifier.Clean(entrada);

            Console.WriteLine($"Prueba {i + 1}:");
            Console.WriteLine($"  Entrada: \"{entrada}\"");
            Console.WriteLine($"  Salida:  \"{salida}\"");
            Console.WriteLine("----------------------------------------------");
        }
    }
