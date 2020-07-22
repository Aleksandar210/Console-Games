using Csharp_Console_Games.Tower_Sweeper_Folder;
using System;

namespace Csharp_Console_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            //TowerSweaper();

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
            Engine currentToweSwapperEngine = new Engine(40,70);
           
           
            
        }
    }
}
