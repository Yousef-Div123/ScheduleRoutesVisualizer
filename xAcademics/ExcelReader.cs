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
        private readonly Dictionary<string, Building> buildingDict;

        public string filePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        public ExcelReader(string fileName) {
            string currentDir = Directory.GetCurrentDirectory();
            string projectRoot = Directory.GetParent(currentDir).Parent.Parent.FullName;
            string excelPath = Path.Combine(projectRoot, "..", fileName);
            filePath = excelPath;

            this.buildingDict = Building.loadBuildings();

        }

        public Dictionary<int, Section> loadSections()
        {
            Dictionary<int, Section> sections = new Dictionary<int, Section>();

            Excel.Application xApp = null;
            Excel.Workbook xWorkBook = null;

            try
            {
                xApp = new Excel.Application();
                xApp.Visible = false;
                xApp.ScreenUpdating = false;
                xApp.DisplayAlerts = false;

                xWorkBook = xApp.Workbooks.Open(filePath);
                Excel.Worksheet xWorksheet = (Excel.Worksheet)xWorkBook.Worksheets[1];
                Excel.Range usedRng = xWorksheet.UsedRange;

                // Read ALL data into array at once (MUCH faster)
                object[,] allData = (object[,])usedRng.Value2;
                int numberOfRows = allData.GetLength(0);

                for (int row = 2; row <= numberOfRows; row++)
                {
                    try
                    {
                        object crnObj = allData[row, 2];
                        object courseCodeObj = allData[row, 3];
                        object departmentObj = allData[row, 4];
                        object sectionNumberObj = allData[row, 5];
                        object courseTitleObj = allData[row, 6];
                        object typeObj = allData[row, 7];
                        object instructorObj = allData[row, 13];

                        // Skip if essential data is missing
                        if (crnObj == null) continue;

                        int crn = Convert.ToInt32(crnObj);
                        string courseCode = courseCodeObj?.ToString() ?? "";
                        string department = departmentObj?.ToString() ?? "";
                        string sectionNumber = sectionNumberObj?.ToString() ?? "";
                        string courseTitle = courseTitleObj?.ToString() ?? "";
                        string type = typeObj?.ToString() ?? "";
                        string instructor = instructorObj?.ToString() ?? "";

                        Section section = new Section
                        (
                            crn: crn,
                            courseCode: courseCode,
                            department: department,
                            sectionNumber: sectionNumber,
                            courseTitle: courseTitle,
                            type: type,
                            instructor: instructor
                        );

                        // Process date information
                        object daysObj = allData[row, 8];
                        object startTimeObj = allData[row, 9];
                        object endTimeObj = allData[row, 10];

                        if (daysObj != null && startTimeObj != null && endTimeObj != null)
                        {
                            string days = daysObj.ToString();
                            if (int.TryParse(startTimeObj.ToString(), out int startTime) &&
                                int.TryParse(endTimeObj.ToString(), out int endTime))
                            {
                                Date date = new Date(days, startTime, endTime);
                                section.date = date;
                            }
                        }

                        // Process building information
                        object buildingCodeObj = allData[row, 11];
                        if (buildingCodeObj != null)
                        {
                            string buildingCode = buildingCodeObj.ToString();
                            if (buildingDict.ContainsKey(buildingCode))
                            {
                                section.building = buildingDict[buildingCode];
                            }
                        }

                        if (!sections.ContainsKey(crn))
                            sections.Add(crn, section);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing row {row}: {ex.Message}");
                        continue;
                    }
                }
            }
            finally
            {
                if (xWorkBook != null)
                {
                    xWorkBook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xWorkBook);
                }
                if (xApp != null)
                {
                    xApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xApp);
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            return sections;
        }

    }
}
