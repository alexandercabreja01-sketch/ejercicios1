using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        if (other == null) return 1;
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(params ProductionRemoteControlCar[] cars)
    {
        var carList = new List<ProductionRemoteControlCar>(cars);
        carList.Sort(); 
        return carList;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== 1 y 2. Prueba en la Pista de Pruebas (TestTrack.Race) ===");
        
        var prodCar = new ProductionRemoteControlCar();
        var expCar = new ExperimentalRemoteControlCar();

        TestTrack.Race(prodCar);
        TestTrack.Race(expCar);

        Console.WriteLine($"Distancia Coche Producción: {prodCar.DistanceTravelled} m (Esperado: 10)");
        Console.WriteLine($"Distancia Coche Experimental: {expCar.DistanceTravelled} m (Esperado: 20)");

        Console.WriteLine("\n=== 3. Clasificación de Coches de Producción (IComparable) ===");

        var prc1 = new ProductionRemoteControlCar { NumberOfVictories = 3 };
        var prc2 = new ProductionRemoteControlCar { NumberOfVictories = 2 };
        var prc3 = new ProductionRemoteControlCar { NumberOfVictories = 5 };

        List<ProductionRemoteControlCar> rankings = TestTrack.GetRankedCars(prc1, prc2, prc3);

        Console.WriteLine("Ranking de coches (orden ascendente por victorias):");
        for (int i = 0; i < rankings.Count; i++)
        {
            Console.WriteLine($" Posición {i + 1}: {rankings[i].NumberOfVictories} victorias");
        }
    }
}
