using System.Collections.Generic;

namespace Core
{
    public class UnitPerformanceProperty
    {
        public int RowIndex { get; set; }
        public string PropertyName { get; set; }

        public static List<UnitPerformanceProperty> GetPerformanceProperties()
        {
            return new List<UnitPerformanceProperty> {
                new UnitPerformanceProperty{ RowIndex = 29, PropertyName = "Fuel Consumption Natural gas" },
                new UnitPerformanceProperty{ RowIndex = 30, PropertyName = "Average Calorific Value Fuel Natural Gas - Low Heating Value" },

                new UnitPerformanceProperty{ RowIndex = 32, PropertyName = "Fuel Consumption HFO" },
                new UnitPerformanceProperty{ RowIndex = 33, PropertyName = "Average Calorific Value Fuel HFO - Low Heating Value" },

                new UnitPerformanceProperty{ RowIndex = 35, PropertyName = "Fuel Consumption ALCO" },
                new UnitPerformanceProperty{ RowIndex = 36, PropertyName = "Average Calorific Value Fuel ALCO - Low Heating Value" },

                new UnitPerformanceProperty{ RowIndex = 38, PropertyName = "Fuel Consumption AHCO" },
                new UnitPerformanceProperty{ RowIndex = 39, PropertyName = "Average Calorific Value Fuel AHCO - Low Heating Value" },

                new UnitPerformanceProperty{ RowIndex = 41, PropertyName = "Fuel Consumption Diesel" },
                new UnitPerformanceProperty{ RowIndex = 42, PropertyName = "Average Calorific Value Fuel Diesel - Low Heating Value" },

                new UnitPerformanceProperty{ RowIndex = 44, PropertyName = "Fuel Consumption Others - Specify" },
                new UnitPerformanceProperty{ RowIndex = 45, PropertyName = "Average Calorific Value Fuel Others - Specify - Low Heating Value" },

                new UnitPerformanceProperty{ RowIndex = 49, PropertyName = "Actual Gross Generation" },
                new UnitPerformanceProperty{ RowIndex = 50, PropertyName = "Actual Net Generation" },

                new UnitPerformanceProperty{ RowIndex = 53, PropertyName = "Compressor inlet air temperature at r.s.c. after TIAC" },
                new UnitPerformanceProperty{ RowIndex = 54, PropertyName = "Gross capacity at last performance test at r.s.c." },
                new UnitPerformanceProperty{ RowIndex = 55, PropertyName = "Net capacity at last performance test at r.s.c." },

                new UnitPerformanceProperty{ RowIndex = 58, PropertyName = "Available hours for all fuel types used" },
                new UnitPerformanceProperty{ RowIndex = 59, PropertyName = "Service Hours" },
                new UnitPerformanceProperty{ RowIndex = 60, PropertyName = "Period Hours" },
                new UnitPerformanceProperty{ RowIndex = 61, PropertyName = "Equivalent Derating Hours" },
                new UnitPerformanceProperty{ RowIndex = 62, PropertyName = "Total Starts" },
                new UnitPerformanceProperty{ RowIndex = 63, PropertyName = "Successful Starts" },
            };
        }
    }
}
