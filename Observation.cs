using System;

namespace QuantumRadar
{
    #region Observation
    public class Observation
    {
        public string plateNum { get; }
        public DateTime Date { get; }
        public CarType carType { get; }
        public double Speed { get; }
        public bool seatbeltFastened { get; }

        public Observation(string plateNumber, DateTime date, CarType cartype,
                            double speed, bool seatbeltfastened)
        {
            this.plateNum = plateNumber;
            this.Date = date;
            this.carType = cartype;
            this.Speed = speed;
            this.seatbeltFastened = seatbeltfastened;
        }
    } 
    #endregion
}
