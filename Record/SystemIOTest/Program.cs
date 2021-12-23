﻿using System;
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
            Console.WriteLine("請輸入資料夾地址");
            dir = Console.ReadLine();
            GetAndChangeFileName();
            Console.WriteLine("已更改完成");
            Console.WriteLine("如果科室(中心、隊)有同名的重複附件，請檢察那個科室的編號順序，按任意鍵結束");
            Console.ReadLine();
            Console.ReadKey();
        }
        static void GetAndChangeFileName()
        {
            string line;
            string WorkReportStr =dir+"\\"+"WorkReport.txt" ;
            string dk = "";
            DirectoryInfo directoryInfo = new DirectoryInfo(@dir);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            int count = 0;
            foreach (var fi in directoryInfo.GetFiles())
            {
                if (fi.Name.Contains("WorkReport.html"))
                {
                    StreamReader streamReader = new StreamReader(dir+"\\"+fi.Name);
                    line = streamReader.ReadLine();
                    
                    while (line != null)
                    {
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
                        
                        if (line.Contains("target")&&line.Contains(".pdf"))
                        {
                            string targetStr = "";
                            bool Istarget = false;
                            foreach (var li in line.Split("\""))
                            {
                                if (li.Contains("target"))
                                {
                                    dictionary.TryAdd(targetStr, dk);
                                }
                                targetStr = li;
                            } 
                        }

                        line = streamReader.ReadLine();
                    }

                    foreach (var di in dictionary)
                    {
                        ChangeName(di.Key,di.Value);
                        //Console.WriteLine(di.Key+":"+di.Value);//模擬資料操作
                        count++;
                    }

                    Console.WriteLine(count);
                    streamReader.Close();
                }
            }
        }
        
        static string dkCheck = "";
        private static int dkCount;
        static void ChangeName(string fileName,string dk)
        {
            if (dkCheck !=dk)
            {
                dkCount = 1;
                dkCheck = dk;
            }
            else
            {
                dkCount++;
            }
            string old = dir + "\\" + fileName;
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
                    dk2NumberStr = "6-7-"+dkCount+"-";
                    break;
                case "政風室":
                    dk2NumberStr = "6-8-"+dkCount+"-";
                    break;
                case "會計室":
                    dk2NumberStr = "6-6-"+dkCount+"-";
                    break;
                case "秘書室":
                    dk2NumberStr = "6-9-"+dkCount+"-";
                    break;
                case "新聞聯絡人":
                    dk2NumberStr = "";
                    break;
            }

            string target = dir+"\\"+
                dk2NumberStr +fileName.Remove(0,7); //fi[1].Remove(0,7);
            //Console.WriteLine(old);
            //Console.WriteLine(target);
            File.Move(old,target);
            //File.Delete(old);
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