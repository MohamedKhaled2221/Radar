using System.Collections.Generic;

namespace QuantumRadar.Rules
{
    #region SeatbeltRule
    public class SeatbeltRule : IRule
    {
        private readonly double _amount;

        public SeatbeltRule(double amount)
        {
            this._amount = amount;
        }

        public string Name => "Seatbelt";

        public List<Violation> Evaluate(Observation observation)
        {
            if (!observation.seatbeltFastened)
            {
                return new List<Violation>
                {
                    new Violation(Name, "Seatbelt not fastned", _amount)
                };
            }
            return new List<Violation>();
        }
    }
    #endregion
}
