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
            //ReadExcel();
            DatatableTest();
        }

        static void DatatableTest()
        {
            DataTable dtTable = new DataTable();
            List<string> rowList = new List<string>();
            List<string> colList = new List<string>(){"A","B","C"};
            for (int i = 0; i < colList.Count; i++)
            {
                dtTable.Columns.Add(colList[i]);
            }

            foreach (var VARIABLE in dtTable.Columns)
            {
                Console.WriteLine(""+VARIABLE);
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
                XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);//取得檔案內的工作簿
                sheet = xssWorkbook.GetSheetAt(0);//取得工作簿中的sheet
                IRow headerRow = sheet.GetRow(0);//取得sheet的第一行，改成1就是取得第2行，(簡單來說就是i-1行)
                int cellCount = headerRow.LastCellNum;//等價於count
                for (int j = 0; j < cellCount; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;//為空直接跳出魂圈，不為空才操作
                    {
                        dtTable.Columns.Add(cell.ToString());
                        Console.WriteLine(cell.ToString());
                    } 
                }

                Console.WriteLine("..........................");
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)//迴圈全部，+1是為了排除第一列
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
            // OpenFileDialog dialog = new OpenFileDialog();
            // dialog.Multiselect = true;//該值確定是否可以選擇多個檔案
            // dialog.Title = "請選擇資料夾";
            // dialog.Filter = "所有檔案(*.*)|*.*";
            // if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            // {
            //     string file = dialog.FileName;
            // }
            
        }
    }
}