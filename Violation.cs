namespace QuantumRadar
{
    public class Violation
    {
        public string ruleName { get; }
        public string Desc { get; }
        public double Amount { get; }

        public Violation(string rulename, string desc, double amount)
        {
            this.ruleName = rulename;
            this.Desc = desc;
            this.Amount = amount;
        }
    }
}
