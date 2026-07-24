using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantumRadar
{
    #region Fine
    public class Fine
    {
        public string plateNum { get; }
        public List<Violation> Violations { get; }
        public double TotalAmount { get; }

        public Fine(string plateNumber, List<Violation> violations)
        {
            this.plateNum = plateNumber;
            this.Violations = violations;
            this.TotalAmount = violations.Sum(v => v.Amount);
        }

        public void Print()
        {
            Console.WriteLine($"Traffic fine for car {plateNum}");
            Console.WriteLine($"Total amount: {TotalAmount:0} EGP");
            Console.WriteLine("Violations:");
            foreach (var v in Violations)
            {
                Console.WriteLine($"{v.Desc} : {v.Amount:0} EGP");
            }
        }
    } 
    #endregion
}
