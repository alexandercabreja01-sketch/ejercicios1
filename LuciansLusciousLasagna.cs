using System;

var lasagna = new Lasagna();

Console.WriteLine("Minutos esperados en el horno: " + lasagna.ExpectedMinutesInOven());
Console.WriteLine("Minutos restantes (llevaba 30 min): " + lasagna.RemainingMinutesInOven(30));
Console.WriteLine("Tiempo de preparación (3 capas): " + lasagna.PreparationTimeInMinutes(3));
Console.WriteLine("Tiempo total transcurrido: " + lasagna.ElapsedTimeInMinutes(3, 30));
public class Lasagna
{
    public int ExpectedMinutesInOven()
    {
        return 40;
    }

    public int RemainingMinutesInOven(int actualMinutes)
    {
        return ExpectedMinutesInOven() - actualMinutes;
    }

    public int PreparationTimeInMinutes(int numberOfLayers)
    {
        return numberOfLayers * 2;
    }

    public int ElapsedTimeInMinutes(int numberOfLayers, int actualMinutesInOven)
    {
        return PreparationTimeInMinutes(numberOfLayers) + actualMinutesInOven;
    }
}
