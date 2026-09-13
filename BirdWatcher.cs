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
            if (count == 0)
                return true;
        return false;
    } 

    public int CountForFirstDays(int numberOfDays)
    {
        int sum = 0;
        for (int i = 0; i < numberOfDays; i++)
            sum = sum + birdsPerDay[i]; 
        return sum;
    }

    public int BusyDays()
    {
        int CounterBusy = 0;
        foreach (int count in birdsPerDay)
            if (count >= 5)
                CounterBusy++;
        return CounterBusy;
    }

    // Método Main para probar todas las funciones en consola
    public static void Main()
    {
        // 1. Probar método estático LastWeek
        int[] lastWeek = BirdCount.LastWeek();
        Console.WriteLine($"Pájaros la semana pasada: {string.Join(", ", lastWeek)}");

        // 2. Crear una instancia para la semana actual
        int[] birdsThisWeek = new int[] { 2, 5, 0, 7, 4, 1, 3 };
        BirdCount birdCount = new BirdCount(birdsThisWeek);

        // 3. Obtener el número de pájaros de hoy (último día del arreglo)
        Console.WriteLine($"Pájaros vistos hoy: {birdCount.Today()}");

        // 4. Incrementar la cuenta de hoy
        birdCount.IncrementTodaysCount();
        Console.WriteLine($"Pájaros vistos hoy (después de incrementar): {birdCount.Today()}");

        // 5. Verificar si hubo algún día sin pájaros (0)
        Console.WriteLine($"¿Hubo algún día sin pájaros?: {birdCount.HasDayWithoutBirds()}");

        // 6. Contar la suma de pájaros de los primeros 4 días
        Console.WriteLine($"Suma de los primeros 4 días: {birdCount.CountForFirstDays(4)}");

        // 7. Contar días ocupados (días con 5 o más pájaros)
        Console.WriteLine($"Días ocupados (>= 5 pájaros): {birdCount.BusyDays()}");
    }
}
