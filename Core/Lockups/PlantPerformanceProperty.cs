using System.Collections.Generic;

namespace Core
{
    public class PlantPerformanceProperty
    {
        public int RowIndex { get; set; }
        public string PropertyName { get; set; }

        public static List<PlantPerformanceProperty> GetPerformanceProperties()
        {
            return new List<PlantPerformanceProperty> {
                new PlantPerformanceProperty{ RowIndex = 68, PropertyName = "Natural Gas" },
                new PlantPerformanceProperty{ RowIndex = 69, PropertyName = "HFO (Heavy Fuel Oil) " },
                new PlantPerformanceProperty{ RowIndex = 70, PropertyName = "ALCO (Arabian Light Crude Oil)" },
                new PlantPerformanceProperty{ RowIndex = 71, PropertyName = "AHCO (Arabian Heavy Crude Oil)" },
                new PlantPerformanceProperty{ RowIndex = 72, PropertyName = "Diesel" },
                new PlantPerformanceProperty{ RowIndex = 73, PropertyName = "Other fuel types total consumption" },
                new PlantPerformanceProperty{ RowIndex = 75, PropertyName = "Actual Gross Generation" },
                new PlantPerformanceProperty{ RowIndex = 76, PropertyName = "Actual Net Generation" },
                new PlantPerformanceProperty{ RowIndex = 79, PropertyName = "Electricity auxiliary consumption at plant level" },
                new PlantPerformanceProperty{ RowIndex = 80, PropertyName = "Imported power from grid" },
            };
        }
    }
}
