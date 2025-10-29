using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace xAcademics
{
    internal class ExcelReader
    {
        private String _filePath;

        public string filePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        public ExcelReader() {
            string currentDir = Directory.GetCurrentDirectory();
            string projectRoot = Directory.GetParent(currentDir).Parent.Parent.FullName;
            string excelPath = Path.Combine(projectRoot, "..", "Term Schedule 251.xlsx");
            filePath = excelPath;

        }

        public ArrayList

        //private void ReadSheetBtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string currentDir = Directory.GetCurrentDirectory();
        //        string projectRoot = Directory.GetParent(currentDir).Parent.Parent.FullName;
        //        string excelPath = Path.Combine(projectRoot, "..", "Term Schedule 251.xlsx");
        //        excelPath = Path.GetFullPath(excelPath);

        //        Excel.Application xApp = new Excel.Application();
        //        Excel.Workbook xWorkBook = xApp.Workbooks.Open(excelPath);
        //        Excel.Worksheet xWorksheet = (Excel.Worksheet)xWorkBook.Worksheets[1];

        //        Excel.Range usedRng = xWorksheet.UsedRange;
        //        int numberOfRows = usedRng.Rows.Count;

        //        // ██████████████████████████████
        //        int row = 2;

        //        xListBox.Items.Clear();
        //        xListBox.Items.Add("Number of Rows = " + numberOfRows.ToString());

        //        while (row <= numberOfRows)
        //        {
        //            Excel.Range rng = xWorksheet.Cells[row, 2];
        //            string CRN = rng.Value;

        //            rng = xWorksheet.Cells[row, 9];
        //            string DateFormat = "HHmm";
        //            DateTime dt = new DateTime();
        //            string startTime;

        //            if (rng.Value == null)
        //            {
        //                startTime = "------";
        //            }
        //            else
        //            {
        //                dt = DateTime.ParseExact(rng.Value.ToString(), DateFormat, CultureInfo.InvariantCulture);
        //                startTime = dt.ToString();
        //            }

        //            xListBox.Items.Add(row.ToString() + ": " + CRN + "     " + startTime);
        //            row++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error " + ex.StackTrace);
        //    }
        //}
    }
}
