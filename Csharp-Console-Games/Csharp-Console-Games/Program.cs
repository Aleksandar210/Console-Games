﻿using Csharp_Console_Games.Tower_Sweeper_Folder;
using System;
using System.Collections.Generic;
using System.Drawing;
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
          
            
            TestingTheFiles();
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

        private static void SwitchConsoleColor(string colorName)
        {
            switch (colorName)
            {
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "LightBlue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "DarkYellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;      
            }
        }

        private static void DisplayMenueOptions(List<string> options,string[] colorsForTheConsole)
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                SwitchConsoleColor(colorsForTheConsole[i]);
                Console.WriteLine(options[i]);
            }
            Console.ResetColor();
        }

        private static void DisplayImageBelowOptions(string imageAscii)
        {
            Console.WriteLine(imageAscii);
        }

        private static void SelecteOption(List<string> options,string[] colors,string imageAsii)
        {
            int currentPositon = 0;
            int previousPositon = 0;
            string selectedOption = null;
            options[currentPositon] = "|" + options[currentPositon] + "|";
            ConsoleKey ch;
            do
            {
                 ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    
                    case ConsoleKey.UpArrow:
                        if(currentPositon-1>=0)
                        {
                            currentPositon -= 1;
                            previousPositon += 1;
                            options[previousPositon] = options[previousPositon].Trim(new char[] { '|' });
                            options[currentPositon] = "|" + options[currentPositon] + "|";
                            DisplayMenueOptions(options, colors);
                            DisplayImageBelowOptions();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentPositon + 1 <=3)
                        {
                            currentPositon += 1;
                            previousPositon -= 1;
                            options[previousPositon] = options[previousPositon].Trim(new char[] { '|' });
                            options[currentPositon] = "|" + options[currentPositon] + "|";
                        }
                        break;
                    case ConsoleKey.Enter:
                        selectedOption = options[currentPositon].Trim(new char[] { '|'});
                        break;

                }

            }
            while (selectedOption is null);

            Console.Clear();
            Console.WriteLine("YOU HAVE SELETED THE {0}", selectedOption);
        }


       

        private static void TestingTheFiles()
        {
            StringBuilder sb = new StringBuilder();
            string[] colorsForTheConsole = new string[] { "Green", "LightBlue", "DarkYellow", "Red" };
            List<string> options = new List<string>();
            options.Add("New Game");
            options.Add("Load Game");
            options.Add("Options");
            options.Add("Quit");
           
            using (var reader = new StreamReader(@"Resources\MainMenueAsciImage.txt"))       //its in resoures folder
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
