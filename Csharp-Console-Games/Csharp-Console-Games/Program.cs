using Csharp_Console_Games.Tower_Sweeper_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

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

            //keep coordinates
            HashSet<string> towerCoordinates = new HashSet<string>();

            Console.Write("Enter number of towers: ");
            int numberTowers = int.Parse(Console.ReadLine());



            //build field
            StringBuilder sb = new StringBuilder();
            char[,] field = new char[40,70];
            for(int i =0;i<numberTowers;i++)
            {
                towerCoordinates.Add(GenerateTowerCoordinates(field,towerCoordinates));
            }

            for(int i =0;i<field.GetLength(0);i++)
            {
               for(int j=0;j<field.GetLength(1);j++)
                {
                    field[i, j] = '.';
                }
            }

            foreach(var item in towerCoordinates)
            {
                BuildTower(field, item.Split(" ").Select(int.Parse).ToArray());
            }

            for(int i =0;i<field.GetLength(0);i++)
            {
                for(int j =0;j<field.GetLength(1);j++)
                {
                    sb.Append(field[i, j]);

                }
                sb.Append(Environment.NewLine);
            }
            Console.WriteLine(sb.ToString());
            



        }

        private static void BuildTower(char[,]field,params int[] coordinates)
        {
            //sdies
            int counterSides = coordinates[0];
            int counterTopsBottoms = coordinates[1];
            for(int i=0;i<5;i++)
            {
                field[coordinates[0], counterTopsBottoms] = '_';
                field[coordinates[0] - 4, counterTopsBottoms] = '-';
                counterTopsBottoms++;
            }
            for(int i =0;i<5;i++)
            {
                field[coordinates[0], coordinates[1]] = '|';
                field[coordinates[0], coordinates[1] + 5] = '|';
                coordinates[0]--;
            }
        }

        private static string GenerateTowerCoordinates(char[,] field,HashSet<string> previousCoordinates)
        {

            int[] coordinates = new int[2];

            do
            {
                coordinates[0] = RandomNumberGenerator(7,field.GetLength(0)-2);
                coordinates[1] = RandomNumberGenerator(1, field.GetLength(1) - 7);
            } while ( coordinates[0]==coordinates[1] && !previousCoordinates.Contains(coordinates[0]+" "+coordinates[1]));

            return coordinates[0]+" "+coordinates[1];
        }

        private static int RandomNumberGenerator(int min, int max)
        {
            Random current = new Random();
            return current.Next(min, max) % max;
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
