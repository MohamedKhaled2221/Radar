using System.Collections.Generic;

namespace QuantumRadar
{
    public interface IRule
    {
        string Name { get; }

        List<Violation> Evaluate(Observation observation);
    }
}
