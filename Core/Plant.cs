using System.Collections.Generic;

namespace Core
{
    public class Plant
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string AdministrativeRegion { get; set; }
        public string LocationName { get; set; }
        public int ReportedYear { get; set; }

        public List<PlantPerformanceData> PlantPerformanceData { get; set; }

    }
}
