using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelReader.Services
{
    public class ExcelDataReader
    {
        private readonly string _filePath;

        public ExcelDataReader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<IXLRow> ReadDataRow()
        {
            using var workbook = new XLWorkbook(_filePath);
            var worksheet = workbook.Worksheet(1);

            foreach (var row in worksheet.RowsUsed().Skip(1))
            {
                yield return row;
            }
        }
    }
}
