using System;
using System.Text;

public static class LimpiadorIdentificador
{
    public static string Limpiar(string identificador)
    {
        if (string.IsNullOrEmpty(identificador))
            return string.Empty;

        var constructorTexto = new StringBuilder();
        bool vieneDeGuion = false;

        foreach (char caracter in identificador)
        {
            if (caracter == ' ')
            {
                constructorTexto.Append('_');
                vieneDeGuion = false;
            }
            else if (char.IsControl(caracter))
            {
                constructorTexto.Append("CTRL");
                vieneDeGuion = false;
            }
            else if (caracter == '-')
            {
                vieneDeGuion = true;
            }
            else if (caracter >= 'α' && caracter <= 'ω')
            {
                vieneDeGuion = false;
            }
            else if (char.IsLetter(caracter))
            {
                if (vieneDeGuion)
                {
                    constructorTexto.Append(char.ToUpperInvariant(caracter));
                    vieneDeGuion = false;
                }
                else
                {
                    constructorTexto.Append(caracter);
                }
            }
            else
            {
                vieneDeGuion = false;
            }
        }

        return constructorTexto.ToString();
    }
}

public class Program
{
    public static void Main()
    {
        
        string prueba1 = LimpiadorIdentificador.Limpiar("my   Id");
        Console.WriteLine($"Prueba 1: \"my   Id\" -> \"{prueba1}\"");

        string prueba2 = LimpiadorIdentificador.Limpiar("my\0Id");
        Console.WriteLine($"Prueba 2: \"my\\0Id\" -> \"{prueba2}\"");

        string prueba3 = LimpiadorIdentificador.Limpiar("à-ḃç");
        Console.WriteLine($"Prueba 3: \"à-ḃç\" -> \"{prueba3}\"");

        string prueba4 = LimpiadorIdentificador.Limpiar("1😀2😀3😀");
        Console.WriteLine($"Prueba 4: \"1😀2😀3😀\" -> \"{prueba4}\"");

        string prueba5 = LimpiadorIdentificador.Limpiar("MyΟβιεγτFinder");
        Console.WriteLine($"Prueba 5: \"MyΟβιεγτFinder\" -> \"{prueba5}\"");
    }
}
