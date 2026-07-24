using System.Collections.Generic;

namespace QuantumRadar.Rules
{
    #region SpeedLimitRule
    public class SpeedLimitRule : IRule
    {
        private readonly CarType _carType;
        private readonly double _maxSpeed;
        private readonly double _amount;

        public SpeedLimitRule(CarType carType, double maxSpeed, double amount)
        {
            this._carType = carType;
            this._maxSpeed = maxSpeed;
            this._amount = amount;
        }

        public string Name => $"Speed limit ({_carType})";

        public List<Violation> Evaluate(Observation observation)
        {
            if (observation.carType == _carType && observation.Speed > _maxSpeed)
            {
                string description = $"speed of {observation.Speed:0} exceeded max allowed {_maxSpeed:0}";
                return new List<Violation> { new Violation(Name, description, _amount) };
            }
            return new List<Violation>();
        }
    } 
    #endregion
}
