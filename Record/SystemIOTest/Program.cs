using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.FileIO;

namespace SystemIOTest
{
    class Program
    {
        private static List<string> files = new List<string>();
        private static string dir = @"D:\xo\XO_github\TestData";
        static void Main(string[] args)
        {
            GetDataTest();
            //Creat();
            files.Clear();
            Console.ReadLine();
        }

        static void GetDataTest()
        {
            string line;
            string WorkReportStr =dir+"\\"+"WorkReport.txt" ;
            string dk = "";
            DirectoryInfo directoryInfo = new DirectoryInfo(@dir);
            foreach (var fi in directoryInfo.GetFiles())
            {
                if (fi.Name.Contains("html"))
                {
                    StreamReader streamReader = new StreamReader(dir+"\\"+fi.Name);
                    line = streamReader.ReadLine();
                    
                    while (line != null)
                    {
                        //Console.WriteLine(line);
                        if (line.Contains("工作報告"))
                        {
                            if (line.Contains("規劃科")) dk = DK.規劃科.ToString();
                            if (line.Contains("設施科")) dk = DK.設施科.ToString();
                            if (line.Contains("工務科")) dk = DK.工務科.ToString();
                            if (line.Contains("工程隊")) dk = DK.工程隊.ToString();
                            if (line.Contains("交控中心")) dk = DK.交控中心.ToString();
                            if (line.Contains("人事室")) dk = DK.人事室.ToString();
                            if (line.Contains("政風室")) dk = DK.政風室.ToString();
                            if (line.Contains("會計室")) dk = DK.會計室.ToString();
                            if (line.Contains("秘書室")) dk = DK.秘書室.ToString();
                            if (line.Contains("新聞聯絡人")) dk = DK.新聞聯絡人.ToString();
                        }
                        if (line.Contains(".pdf"))
                        {
                            Console.WriteLine(dk);
                            //Console.WriteLine(line);
                            GetFileAndChangeName(line,dk); //取得及更改檔案名稱
                        }
                        line = streamReader.ReadLine();
                    }
                    streamReader.Close();
                }
            }
        }
        static string dkCheck;
        private static int dkCount;
        static void GetFileAndChangeName(string line,string dk)
        {
            if (dkCheck == null ||dkCheck !=dk)
            {
                dkCount = 1;
                dkCheck = dk;
            }
            else
            {
                dkCount++;
            }

            string[] fi = line.Split("\"");
            string old =dir+"\\"+ fi[1];
            string dk2NumberStr = "";
            switch (dk)
            {
                case "規劃科":
                    dk2NumberStr = "6-1-"+dkCount+"-";
                    break;
                case "設施科":
                    dk2NumberStr = "6-2-"+dkCount+"-";
                    break;
                case "工務科":
                    dk2NumberStr = "6-3-"+dkCount+"-";
                    break;
                case "工程隊":
                    dk2NumberStr = "6-4-"+dkCount+"-";
                    break;
                case "交控中心":
                    dk2NumberStr = "6-5-"+dkCount+"-";
                    break;
                case "人事室":
                    dk2NumberStr = "6-6-"+dkCount+"-";
                    break;
                case "政風室":
                    dk2NumberStr = "6-7-"+dkCount+"-";
                    break;
                case "會計室":
                    dk2NumberStr = "6-8-"+dkCount+"-";
                    break;
                case "秘書室":
                    dk2NumberStr = "6-9-"+dkCount+"-";
                    break;
                case "新聞聯絡人":
                    dk2NumberStr = "";
                    break;
            }
            
            string target =dir+"\\"+dk2NumberStr+ fi[1].Remove(0,7);
            Console.WriteLine(old);
            Console.WriteLine(target);
            File.Move(old,target);
            //File.Delete(old);
        }
        static void Creat()
        {
            for (int i = 0; i < 10; i++)
            {
                string filedi = dir +"\\"+i+".txt";
                files.Add(filedi);
                File.WriteAllText(@filedi,i.ToString());
            }
        }

        enum DK
        {
            規劃科,
            設施科,
            工務科,
            工程隊,
            交控中心,
            人事室,
            政風室,
            會計室,
            秘書室,
            新聞聯絡人
        }

    }
}