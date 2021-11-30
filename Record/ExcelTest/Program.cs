using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Newtonsoft.Json;
namespace ExcelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamTest();
        }


        static void StreamTest()
        {
            using (FileStream stream = new FileStream("Test.txt",FileMode.OpenOrCreate))
            {
            }

            using (StreamWriter streamWriter = new StreamWriter("Test.txt") )
            {
                streamWriter.WriteLine("aaa");
            }
        }

        static void OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//該值確定是否可以選擇多個檔案
            dialog.Title = "請選擇資料夾";
            dialog.Filter = "所有檔案(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
            }
            
        }
        
        
        
        static string ReadExcel()
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            ISheet sheet;
            using (var stream = new FileStream("TestData.xlsx", FileMode.Open))//根據路徑取得FileStream
            {
                stream.Position = 0;
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                sheet = xssWorkbook.GetSheetAt(0);
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;
                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                    {
                        dtTable.Columns.Add(cell.ToString());
                        Console.WriteLine(cell.ToString());
                    } 
                }
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                            {
                                rowList.Add(row.GetCell(j).ToString());
                                Console.WriteLine(row.GetCell(j).ToString());

                            }
                        }
                    }
                    if(rowList.Count>0)
                        dtTable.Rows.Add(rowList.ToArray());
                    rowList.Clear(); 
                }
            }
            return JsonConvert.SerializeObject(dtTable);
        }
        
    }
}