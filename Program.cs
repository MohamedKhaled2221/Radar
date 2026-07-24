using System;
using QuantumRadar.Rules;

namespace QuantumRadar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var radar = new QuantumRadarEngine();

            radar.AddRule(new SeatbeltRule(100));
            radar.AddRule(new SpeedLimitRule(CarType.Truck, 60, 300));
            radar.AddRule(new SpeedLimitRule(CarType.Private, 80, 300));

            var observations = new[]
            {
                new Observation("ABC1234", DateTime.Now, CarType.Private, 94, false),
                new Observation("XYZ9876", DateTime.Now, CarType.Truck, 55, true),
                new Observation("TRK5555", DateTime.Now, CarType.Truck, 72, true),
                new Observation("ABC1234", DateTime.Now, CarType.Private, 85, true),
            };

            foreach (var obs in observations)
            {
                var fine = radar.ProcessObservation(obs);
                if (fine != null)
                {
                    fine.Print();
                    Console.WriteLine();
                }
            }

            radar.PrintAllFinesByPlate();
            Console.WriteLine();
            radar.PrintViolatedRuleCounts();
        }
    }
}
