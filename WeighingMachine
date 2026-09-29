using System;
using System.Globalization;

public class WeighingMachine
{
    private double _weight;

    public int Precision { get; }

    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "El peso no puede ser negativo.");
            }
            _weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5.0;


    public string DisplayWeight
    {
        get
        {
            double adjustedWeight = Weight - TareAdjustment;
            // Formateamos el número según la precisión especificada y CultureInfo.InvariantCulture para asegurar el punto decimal
            string formattedWeight = adjustedWeight.ToString($"F{Precision}", CultureInfo.InvariantCulture);
            return $"{formattedWeight} kg";
        }
    }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== Tarea 1 y 5: Precision y TareAdjustment por defecto ===");
        var wm = new WeighingMachine(precision: 3);
        Console.WriteLine($"Precision: {wm.Precision} (Esperado: 3)");
        Console.WriteLine($"TareAdjustment inicial: {wm.TareAdjustment} (Esperado: 5.0)");

        Console.WriteLine("\n=== Tarea 2: Weight (get y set) ===");
        wm.Weight = 60.5;
        Console.WriteLine($"Weight: {wm.Weight} (Esperado: 60.5)");

        Console.WriteLine("\n=== Tarea 3: Validación de Weight negativo ===");
        try
        {
            wm.Weight = -10;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Excepción capturada correctamente: {ex.GetType().Name}");
        }

        Console.WriteLine("\n=== Tarea 4 y 6: TareAdjustment personalizado y DisplayWeight ===");
        var wm2 = new WeighingMachine(precision: 3);
        wm2.Weight = 60.567;
        wm2.TareAdjustment = 10;
        Console.WriteLine($"DisplayWeight con tara 10: '{wm2.DisplayWeight}' (Esperado: '50.567 kg')");

        var wm3 = new WeighingMachine(precision: 2);
        wm3.Weight = 70.0;
        wm3.TareAdjustment = -5.5; // La tara también puede ser negativa
        Console.WriteLine($"DisplayWeight con tara negativa: '{wm3.DisplayWeight}' (Esperado: '75.50 kg')");
    }
}
