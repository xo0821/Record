using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Security;
namespace RandomMap
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayOperate.DrawArry(ArrayOperate.CteatArray(4, 4,"0000001000101110"));
            Console.ReadLine();
        }
    }
    
        public static partial class ArrayOperate
    {
        public  static bool fill()
        {
            Vector2 v = new Vector2();

            return true;
        }
        
        public static Boolean inArea(int[,]image, int x, int y){
            return x>=0&&x<image.Length&&y>=0&&y<image.GetLength(0);
        }
        public static void DrawArry(int[,] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i,j]);
                }
                Console.WriteLine();
            }
        }
        public static int[,] CteatArray_SquareDivision(int x,int y)//創建數字順序的九宮格
        {
            int s =0;
            int[,] a = new int[x,y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    s++;
                    a[i,j] = s;
                }
            }
            return a;
        }
        public static int[,] CteatArray(int x,int y,string str)
        {
            List<int> list = StringToInt(str);
            int s =0;
            int[,] a = new int[x,y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    a[i,j] = list[s];
                    s++;
                }
            }
            return a;
        }
        static List<int> StringToInt(string s)
        {
            var l = GetChar(s, 1);
            var i =new List<int>();
            foreach (var item in l)
            {
                i.Add((int.Parse(item)));
            }

            return i;
        }
        static IEnumerable<string> GetChar(string source,int deg)
        {
            var words = new List<string>();
            for (int i = 0; i < source.Length; i+=deg)
            {
                if (source.Length-i>=deg) words.Add(source.Substring(i,deg));
                else
                {
                    words.Add(source.Substring(i,source.Length-i));  
                }
            }
            return words;
        }
    }
}