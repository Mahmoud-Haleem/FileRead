using System.Collections.Generic;

namespace Core
{
    public class Unit
    {
        public int UnitId { get; set; }

        public int RequestId { get; set; }

        public string Name { get; set; }

        public int CommissioningYear { get; set; }

        public int RetirementYear { get; set; }

        public string RetirementRationale { get; set; }

        public List<UnitPerformanceData> UnitPerformanceData { get; set; }

        public UnitCalculation UnitCalculation { get; set; }
    }
}
