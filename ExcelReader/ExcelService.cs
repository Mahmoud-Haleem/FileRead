using Core;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelReader
{
    public class ExcelService
    {
        public static void GetFileData()
        {
            Worksheet sheet = GetExcelSheet();

            var request = new Request() { Technology = new Technology() { Name = "GTP" } };

            GetPlantInfo(sheet, request);
            GetPlantPerformanceData(sheet, request);

            GetUnitInfo(sheet, request);
            GetUnitPerformanceData(sheet, request);

            var result = JsonConvert.SerializeObject(request);
        }

        private static Worksheet GetExcelSheet()
        {
            #region Read Excel File
            string filePath = $"C:/ELM/File/GTP.xlsx";
            ApplicationClass app = new ApplicationClass();
            Workbook book = app.Workbooks.Open(filePath);
            Worksheet sheet = (Worksheet)book.Worksheets[1];
            #endregion
            return sheet;
        }

        /// <summary>
        /// Get Plant Information
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="request"></param>
        private static void GetPlantInfo(Worksheet sheet, Request request)
        {
            request.Plant = new Plant();

            // we can configure cell name by use comma separated in Technology tabel prop
            request.Plant.CompanyName = sheet.GetCellValue("G8");
            request.Plant.Name = sheet.GetCellValue("G9");
            request.Plant.AdministrativeRegion = sheet.GetCellValue("G10");
            request.Plant.LocationName = sheet.GetCellValue("G11");
            request.Plant.ReportedYear = sheet.GetCellValueToInt("G12");
        }
        
        /// <summary>
        /// Get Plant Performace Data
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="request"></param>
        private static void GetPlantPerformanceData(Worksheet sheet, Request request)
        {
            PlantPerformanceData? plantPerformance = null;
            List<PlantPerformanceProperty> plantPerformanceProperties = PlantPerformanceProperty.GetPerformanceProperties();

            request.Plant.PlantPerformanceData = new List<PlantPerformanceData>();

            foreach (var prop in plantPerformanceProperties)
            {
                plantPerformance = new PlantPerformanceData();
                plantPerformance.Key = prop.PropertyName;
                plantPerformance.Value = sheet.GetCellValue(prop.RowIndex, request.Technology.PlantPerformanceIndexColumn);

                request.Plant.PlantPerformanceData.Add(plantPerformance);
            }
        }

        private static void GetUnitInfo(Worksheet sheet, Request request)
        {
            Unit? unit = null;
            request.Units = new List<Unit>();

            //Configure (cell name of first table data) in Technology tabel prop
            object[,] unitsInfoData = sheet.GetSubTable(firstTableCell: request.Technology.UnitInfoFirstCell);

            for (int col = 1; col <= unitsInfoData.GetLength(1); col++)
            {
                unit = new Unit();

                unit.Name = unitsInfoData[1, col].ToString();
                unit.CommissioningYear = int.TryParse(unitsInfoData[2, col].ToString(), out int commissonYear) ? commissonYear : 0;
                unit.RetirementYear = int.TryParse(unitsInfoData[3, col].ToString(), out int retirementYear) ? retirementYear : 0;
                unit.RetirementRationale = unitsInfoData[4, col].ToString();

                request.Units.Add(unit);
            }
        } 

        private static void GetUnitPerformanceData(Worksheet sheet, Request request)
        {
            UnitPerformanceData? unitPerformance = null;
            List<UnitPerformanceProperty> unitProperties = UnitPerformanceProperty.GetPerformanceProperties();
            
            foreach (var unit in request.Units)
            {
                unit.UnitPerformanceData = new List<UnitPerformanceData>();

                //Configure (index of first column which contain unit data) in Technology tabel prop
                //Range range = sheet.get_Range("H29");
                int col = request.Technology.UnitPerformanceStartIndexColumn + request.Units.IndexOf(unit);

                foreach (var prop in unitProperties)
                {
                    unitPerformance = new UnitPerformanceData();
                    unitPerformance.Key = prop.PropertyName;
                    unitPerformance.Value = sheet.GetCellValue(prop.RowIndex, col);
                    unit.UnitPerformanceData.Add(unitPerformance);
                }
            }
        }
    }

   
}
