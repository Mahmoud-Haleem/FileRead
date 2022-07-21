using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelReader
{
    public static class ExcelExtensions
    {
        public static string? GetCellValue(this Worksheet sheet, int row, int col)
        {
            return ((Range)sheet.Cells[row, col]).Value2 == null ? null : ((Range)sheet.Cells[row, col]).Value2.ToString();
        }

        /// <summary>
        /// Get Cell value
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="cell">e.g G8 </param>
        /// <returns></returns>
        public static string GetCellValue(this Worksheet sheet, string cell)
        {
            return sheet.get_Range(cell).Value2 == null ? string.Empty : sheet.get_Range(cell).Value2.ToString();
        }

        public static int GetCellValueToInt(this Worksheet sheet, string cell)
        {
            return int.TryParse(sheet.get_Range(cell).Value2?.ToString(), out int value) ? value : 0;
        }

        public static object[,] GetSubTable(this Worksheet sheet, string firstTableCell)
        {
            Range range = sheet.get_Range(firstTableCell);
            range = range.get_End(XlDirection.xlToRight);
            range = range.get_End(XlDirection.xlDown);
            string downAddress = range.get_Address(false, false, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);
            range = sheet.get_Range(firstTableCell, downAddress);
            object[,] unitTableExValues = (object[,])range.Value2;
            return unitTableExValues;
        }
    }
}
