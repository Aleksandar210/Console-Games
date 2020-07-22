

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    class Engine
    {
        //usable resoures
        private readonly StringBuilder sb;

        //consts
        private const int DefaultNumberTowerSweeped = 0;

        //fields
        private int numberTowerSweeped;
        private Player player;
        private Dictionary<string, Enemy> enemiesOnField;
        private char[,] field;

        //contructors
        public Engine(int row, int column)
        {
            this.numberTowerSweeped = DefaultNumberTowerSweeped;
            this.field = new char[row, column];
            this.sb = new StringBuilder();
            this.BuildFieldOnStartup(row, column);
            
        }

        //properties
        private string Field        //updated for real time rendering such as only partial updated
                                    //this will do for now //Same as for room use back buffer programming 
        {
             set
            {
                this.sb.Clear();
                for(int i =0;i<this.field.GetLength(0);i++)
                {
                    for(int j=0;j<this.field.GetLength(1);j++)
                    {
                        this.sb.Append(this.field[i, j]);
                    }
                   this.sb.Append(Environment.NewLine);
                }
            }
            get
            {
                this.Field = "hello world";
                return this.sb.ToString();
            }
        }


        //Room -> inside the towe  //Tower can have multiple floors with rooms 
        private string Room 
        {
            
             set
            {
                this.sb.Clear();
                for(int i =0;i<this.field.GetLength(0);i++)
                {
                    for(int j=0;j<this.field.GetLength(1);j++)
                    {
                        this.sb.Append(this.field[i, j]);
                    }
                    sb.Append(Environment.NewLine);
                }
            }
            get { return this.sb.ToString(); }
        }

        //behaviour
        private void BuildFieldOnStartup(int row,int col)     //updated for random object placements
        {
            
            for(int i=0;i<this.field.GetLength(0);i++)
            {
                for(int j =0;j<this.field.GetLength(1);j++)
                {
                    this.field[i, j] = '.';
                }
            }

        }

        private void MainMenue()
        {
            int select;
            do
            {
                this.sb.Clear();
                Console.Clear();
                sb.Append($"1| New Game." + Environment.NewLine);
                //add load game in future instances and maybe options
                sb.Append($"2| Exit." + Environment.NewLine);
                Console.Write("Select: ");
                select = int.Parse(Console.ReadLine());
            } while (select < 1 || select > 2);
            switch(select)
            {
                case 1:

                    break;
                case 2:

                    break;
            }
             
        }

        public void DisplayFieldOnScreen()
        {
            Console.Clear();
            Console.WriteLine(this.Field);
        }

        
    }
}
