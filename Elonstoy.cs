using System;

public class RemoteControlCar
{
    private int _distanceDriven = 0;
    private int _batteryPercentage = 100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_distanceDriven} meters";
    }

    public string BatteryDisplay()
    {
        if (_batteryPercentage == 0)
        {
            return "Battery empty";
        }

        return $"Battery at {_batteryPercentage}%";
    }

    public void Drive()
    {
        if (_batteryPercentage > 0)
        {
            _distanceDriven += 20;
            _batteryPercentage -= 1;
        }
    }
    class Program
{
    static void Main(string[] args)
    {


        RemoteControlCar car = RemoteControlCar.Buy();
        Console.WriteLine("1. Se ha comprado un auto nuevo.");

        Console.WriteLine($"2. Pantalla Distancia: {car.DistanceDisplay()}");
        Console.WriteLine($"3. Pantalla Batería:   {car.BatteryDisplay()}\n");


        Console.WriteLine("Manejando el auto 2 veces...");
        car.Drive();
        car.Drive();
        Console.WriteLine($"4. Nueva Distancia: {car.DistanceDisplay()}");
        Console.WriteLine($"5. Nueva Batería:   {car.BatteryDisplay()}\n");

        Console.WriteLine("Agotando la batería por completo (98 viajes más)...");
        for (int i = 0; i < 98; i++)
        {
            car.Drive();
        }

        Console.WriteLine($"   Estado tras 100 viajes -> {car.DistanceDisplay()} | {car.BatteryDisplay()}");

    
        Console.WriteLine("Intentando manejar una vez más con batería en 0%...");
        car.Drive();
        Console.WriteLine($"6. Distancia Final: {car.DistanceDisplay()}");
        Console.WriteLine($"   Batería Final:   {car.BatteryDisplay()}");

    }
}
}
