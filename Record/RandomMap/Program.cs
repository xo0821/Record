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
            bool b = false;
            int[,] a = ArrayOperate.CteatArray(4, 4, "0000001000101110");
            ArrayOperate.DrawArry(a);
            Console.WriteLine("..........................");
            Console.WriteLine(ArrayOperate.floodfill(0,0,3,3,a));
            Console.WriteLine("..........................");
            ArrayOperate.DrawArry(a);
            Console.ReadLine();
        }
    }
    
        public static partial class ArrayOperate
    {
        public static bool floodfill(int start_x,int start_y,int target_x,int target_y,int[,] arrayInts)
        {
            Vector2 v = new Vector2();
           return floodfill(start_x,start_y,target_x,target_y,arrayInts,out v);
        }

        public  static bool floodfill(int start_x,int start_y,int target_x,int target_y,int[,] arrayInts, out Vector2 vector2)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start_x);
            queue.Enqueue(start_y);
            while (queue.Count ==0)
            {
                int x,y;
                x = queue.Dequeue();
                y = queue.Dequeue();
                if (arrayInts[x,y] ==arrayInts[target_x,target_y])
                {
                    vector2.X = x;
                    vector2.Y = y;
                    return true;
                }
                else
                {
                    if (arrayInts[x,y+1] == 0&&inArea(arrayInts,x,y+1)){queue.Enqueue(x);queue.Enqueue(y+1);}
                    if (arrayInts[x,y-1] == 0&&inArea(arrayInts,x,y-1)){queue.Enqueue(x);queue.Enqueue(y-1);}
                    if (arrayInts[x+1,y] == 0&&inArea(arrayInts,x+1,y)){queue.Enqueue(x+1);queue.Enqueue(y);}
                    if (arrayInts[x-1,y] == 0&&inArea(arrayInts,x-1,y)){queue.Enqueue(x-1);queue.Enqueue(y);}
                }
            }
            vector2 = Vector2.Zero;
            return false;
        }
        
        public static Boolean inArea(int[,]arrayInts, int x, int y){
            return x>=0&&x<=arrayInts.GetLength(0)-1&&y>=0&&y<=arrayInts.GetLength(1)-1;
        }
        public static void DrawArry(int[,] arrayInts)
        {
            for (int i = 0; i <= arrayInts.GetLength(0)-1; i++)
            {
                for (int j = 0; j <= arrayInts.GetLength(1)-1; j++)
                {
                    Console.Write(arrayInts[i,j]);
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