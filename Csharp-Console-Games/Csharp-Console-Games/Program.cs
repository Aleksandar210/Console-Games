using Csharp_Console_Games.Tower_Sweeper_Folder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Csharp_Console_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            // TowerSweaper();
            TestingFiles2();
            //TestingTheFiles();
            //experiment with random numbers
            // Console.Write("Enter min range: ");
            // int min = int.Parse(Console.ReadLine());
            // Console.Write("Enter max range: ");
            // int max = int.Parse(Console.ReadLine());
            //for(int i =0;i<max;i++)
            //{
            //    Console.WriteLine(GenerateRandomNumber(1, max));
            // }



            
        }

      

       
        private static void TestingTheFiles()
        {
            StringBuilder sb = new StringBuilder();
            using (var reader = new StreamReader(@"Resources\EnemiesNamesStats.txt"))       //its in resoures folder
            {
                while(reader.Peek()>=0)
                {
                    sb.Append(reader.ReadLine() + Environment.NewLine);
                }
            }

            Console.WriteLine(sb.ToString());
        }
        

      

        //WORKS
        //experimetn with random numbers
       // private static int GenerateRandomNumber(int min, int max)
        //{
         //   Random ran = new Random();
          //  return ran.Next(min, max) % max;

        //}

        private static void TowerSweaper()
        {
            // 40 by 70 is perfect on full tab
            Engine currentToweSwapperEngine = new Engine();
            currentToweSwapperEngine.DisplayFieldOnScreen();
           
           
            
        }
    }
}
