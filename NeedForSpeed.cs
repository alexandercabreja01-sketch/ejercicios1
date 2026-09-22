using System;

class RemoteControlCar
{
    private readonly int _speed;
    private readonly int _batteryDrain;
    private int _distanceDriven = 0;
    private int _batteryLeft = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _batteryLeft < _batteryDrain;
    }

    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _distanceDriven += _speed;
            _batteryLeft -= _batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }

    public int Speed => _speed;
    public int BatteryDrain => _batteryDrain;
    public int BatteryLeft => _batteryLeft;
}

class RaceTrack
{
    private readonly int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int drivesNeeded = (int)Math.Ceiling((double)_distance / car.Speed);
        int totalBatteryNeeded = drivesNeeded * car.BatteryDrain;

        return totalBatteryNeeded <= 100;
    }
}

class Program
{
    static void Main()
    {
        
        int speed = 5;
        int batteryDrain = 2;
        var car = new RemoteControlCar(speed, batteryDrain);
        var track800 = new RaceTrack(800);

        Console.WriteLine($"1. Coche creado -> Velocidad: {car.Speed} m/s | Consumo: {car.BatteryDrain}% por impulso");
        Console.WriteLine($"2. Pista creada -> Distancia: 800 metros");

        car.Drive();
        Console.WriteLine($"3. Distancia recorrida tras 1 impulso: {car.DistanceDriven()} metros");
        Console.WriteLine($"   Batería restante: {car.BatteryLeft}%");
        Console.WriteLine($"4. ¿Batería agotada?: {car.BatteryDrained()}");

        Console.WriteLine("Prueba del Modelo Nitro");
        var nitro = RemoteControlCar.Nitro();
        nitro.Drive();
        Console.WriteLine($"5. Modelo Nitro creado -> Impulso inicial: {nitro.DistanceDriven()} metros recorridos");
        Console.WriteLine($"   Batería restante Nitro: {nitro.BatteryLeft}%");

        Console.WriteLine("Evaluación de Carreras (TryFinishTrack) ");

        bool puedeTerminarA = track800.TryFinishTrack(car);
        Console.WriteLine($" ¿Coche (vel: 5, drain: 2%) termina pista de 800m?: {puedeTerminarA}");

        var track200 = new RaceTrack(200);
        bool puedeTerminarB = track200.TryFinishTrack(car);
        Console.WriteLine($" ¿Coche (vel: 5, drain: 2%) termina pista de 200m?: {puedeTerminarB}");

        var track1000 = new RaceTrack(1000);
        bool puedeTerminarC = track1000.TryFinishTrack(nitro);
        Console.WriteLine($" ¿Nitro (vel: 50, drain: 4%) termina pista de 1000m?: {puedeTerminarC}");
    }
}
