public class Lasagna
{
    private const int MinutesPerLayer = 2;
    private const int ExpectedMinutes = 40;

    public int ExpectedMinutesInOven()
    {
        return ExpectedMinutes;
    }

    public int RemainingMinutesInOven(int actualMinutesInOven)
    {
        return ExpectedMinutesInOven() - actualMinutesInOven;
    }

    public int PreparationTimeInMinutes(int numberOfLayers)
    {
        return numberOfLayers * MinutesPerLayer;
    }

    public int ElapsedTimeInMinutes(int numberOfLayers, int minutesInOven)
    {
        return PreparationTimeInMinutes(numberOfLayers) + minutesInOven;
    }
}