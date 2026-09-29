using System;

public static class CarsAssemble
{
    public static double ProductionRatePerHour(int speed)
    {
        double successRate;

        if (speed >= 1 && speed <= 4)
        {
            successRate = 1.0;
        }
        else if (speed >= 5 && speed <= 8)
        {
            successRate = 0.9;
        }
        else if (speed == 9)
        {
            successRate = 0.8;
        }
        else if (speed == 10)
        {
            successRate = 0.77;
        }
        else
        {
            successRate = 0.0;
        }

        return speed * 221 * successRate;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("     PRUEBA DE PRODUCCIÓN - FABRICA DE AUTOS   ");
        Console.WriteLine("==============================================\n");

        // aqui se prueba con diferentes velocidades
        int[] velocidades = { 0, 3, 6, 9, 10 };

        foreach (int speed in velocidades)
        {
            double autosPorHora = CarsAssemble.ProductionRatePerHour(speed);
            int autosPorMinuto = CarsAssemble.WorkingItemsPerMinute(speed);

            Console.WriteLine($"[Velocidad {speed}]");
            Console.WriteLine($"  - Producción por hora:   {autosPorHora}");
            Console.WriteLine($"  - Producción por minuto: {autosPorMinuto} autos/min");
            Console.WriteLine("----------------------------------------------");
        }
    }
}
