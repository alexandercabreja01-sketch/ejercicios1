using System;

public class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int count in birdsPerDay)
        {
            if (count == 0)
            {
                return true;
            }
        }
        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int total = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            total += birdsPerDay[i];
        }
        return total;
    }

    public int BusyDays()
    {
        int busyDaysCount = 0;
        foreach (int count in birdsPerDay)
        {
            if (count >= 5)
            {
                busyDaysCount++;
            }
        }
        return busyDaysCount;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("        MONITOR DE CONTEO DE AVES             ");

        int[] lastWeek = BirdCount.LastWeek();
        Console.WriteLine($"1. Conteos de la semana pasada: [{string.Join(", ", lastWeek)}]");

        int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
        BirdCount birdCount = new BirdCount(birdsPerDay);
        Console.WriteLine($"   Conteos de esta semana:    [{string.Join(", ", birdsPerDay)}]\n");

        Console.WriteLine($"2. Aves que visitaron HOY: {birdCount.Today()}");

        birdCount.IncrementTodaysCount();
        Console.WriteLine($"3. Incrementando el conteo de hoy...");
        Console.WriteLine($"   Nuevo conteo de HOY: {birdCount.Today()}");

        Console.WriteLine($"4. ¿Hubo algún día sin aves (0)? {birdCount.HasDayWithoutBirds()}");

        int dias = 4;
        Console.WriteLine($"5. Total de aves en los primeros {dias} días: {birdCount.CountForFirstDays(dias)}");

        Console.WriteLine($"6. Número de días ocupados (>= 5 aves): {birdCount.BusyDays()}");
        
    }
}
