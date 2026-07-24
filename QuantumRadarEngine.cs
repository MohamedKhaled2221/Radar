using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantumRadar
{
    #region QuantumRadarEngine
    public class QuantumRadarEngine
    {
        private readonly List<IRule> _rules = new List<IRule>();
        private readonly List<Fine> _issuedFines = new List<Fine>();

        private readonly Dictionary<string, double> _totalsPlate = new Dictionary<string, double>();
        private readonly Dictionary<string, int> _violationCounts = new Dictionary<string, int>();

        public void AddRule(IRule rule)
        {
            _rules.Add(rule);
        }

        public Fine ProcessObservation(Observation observation)
        {
            var violations = new List<Violation>();

            foreach (var rule in _rules)
            {
                var res = rule.Evaluate(observation);
                if (res != null && res.Count > 0)
                {
                    violations.AddRange(res);
                    _violationCounts[rule.Name] = _violationCounts.GetValueOrDefault(rule.Name, 0) + res.Count;
                }
            }

            if (violations.Count == 0)
            {
                return null;
            }

            var fine = new Fine(observation.plateNum, violations);
            _issuedFines.Add(fine);
            _totalsPlate[observation.plateNum] =
                _totalsPlate.GetValueOrDefault(observation.plateNum, 0) + fine.TotalAmount;

            return fine;
        }

        public List<Fine> IssuedFines => _issuedFines;

        public Dictionary<string, double> GetAllAmountsByPlate() => _totalsPlate;

        public Dictionary<string, int> GetViolationCountsByRule() => _violationCounts;

        public void PrintAllFinesByPlate()
        {
            Console.WriteLine("All Amounts");
            foreach (var x in _totalsPlate)
            {
                Console.WriteLine($"{x.Key} : {x.Value:0} pound ");
            }
        }

        public void PrintViolatedRuleCounts()
        {
            Console.WriteLine("All Rules");
            foreach (var x in _violationCounts)
            {
                Console.WriteLine($"{x.Key} : {x.Value}");
            }
        }
    } 
    #endregion
}
