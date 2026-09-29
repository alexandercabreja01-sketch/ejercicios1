using System;

namespace RedRemoteControlCarTeam
{
    public class Motor
    {
        public string Model => "V8 Supercharged";
    }

    public class Telemetry
    {
        public int SignalStrength => 95;
    }

    public class RemoteControlCar
    {
        public Motor Motor { get; } = new Motor();
        public Telemetry Telemetry { get; } = new Telemetry();
        public int Speed { get; private set; } = 0;

        public void Drive()
        {
            Speed += 12;
        }
    }
}

namespace BlueRemoteControlCarTeam
{
    public class Motor
    {
        public string Model => "Dual Electric";
    }

    public class Telemetry
    {
        public int SignalStrength => 88;
    }

    public class RemoteControlCar
    {
        public Motor Motor { get; } = new Motor();
        public Telemetry Telemetry { get; } = new Telemetry();
        public int Speed { get; private set; } = 0;

        public void Drive()
        {
            Speed += 15;
        }
    }
}

namespace RemoteControlCompetition
{
    using Red = RedRemoteControlCarTeam;
    using Blue = BlueRemoteControlCarTeam;

    public class Program
    {
        public static void Main(string[] args)
        {
            Red.RemoteControlCar redCar = new Red.RemoteControlCar();
            Blue.RemoteControlCar blueCar = new Blue.RemoteControlCar();

            redCar.Drive();
            blueCar.Drive();

            Console.WriteLine("=== Resultados de la Competencia ===");
            Console.WriteLine($"Coche Rojo - Motor: {redCar.Motor.Model} | Velocidad: {redCar.Speed} km/h | Señal: {redCar.Telemetry.SignalStrength}%");
            Console.WriteLine($"Coche Azul - Motor: {blueCar.Motor.Model} | Velocidad: {blueCar.Speed} km/h | Señal: {blueCar.Telemetry.SignalStrength}%");
        }
    }
}
