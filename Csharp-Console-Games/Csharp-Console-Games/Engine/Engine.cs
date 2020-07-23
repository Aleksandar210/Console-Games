

using Csharp_Console_Games.Tower_Sweeper_Folder.Buildings;
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
        private HashSet<string> towerCoordiantes;


        //consts
        private const int DefaultNumberTowerSweeped = 0;
        private const int fieldRow = 40;
        private const int fieldCol = 70;

        //fields
        private int numberTowerSweeped;
        private int numberTowersOnTheField;
        private int numberEnemiesOnTheField;
        private Player player;
        private Dictionary<string, Enemy> enemiesOnField;
        private Dictionary<string, Tower> towersOnTheField;
        private char[,] field;

        //contructors
        public Engine()
        {
            this.numberTowerSweeped = DefaultNumberTowerSweeped;        //initialise number towers sweeped
            enemiesOnField = new Dictionary<string, Enemy>();           //intialise enemies collection
            towersOnTheField = new Dictionary<string, Tower>();         //initialise towerCoolection
            this.field = new char[fieldRow, fieldCol];                  //initialise field 2d array
            this.sb = new StringBuilder();                              //initialise stringBuilder
            this.BuildFieldOnStartup();                                 //execute build field func
            
        }
        //------------------------------------------------------------------------------------------



        //PROPERTIES
        //-------------------------------------------------------------------------------------------
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

        private int NumberEnemiesOnTheField => this.enemiesOnField.Count;

        private int NumberTowersOnTheField => this.towersOnTheField.Count;

        //---------------------------------------------------------------------------------




        //BEHAVIOUR
        //---------------------------------------------------------------------------------
        //behaviour
        private void BuildFieldOnStartup()     //updated for random object placements
        {
            int numberTowersTheFiledHas = RandomTowerNumberGenerator();
            int numberEnemiesTheFieldHas = RandomNumberEnemeyGenerator();
            
            for(int i=0;i<this.field.GetLength(0);i++)
            {
                for(int j =0;j<this.field.GetLength(1);j++)
                {
                    this.field[i, j] = '.';
                }
            }

        }

        
        /// <summary>
        ///generates coordinates for a tower randomyl and within range
        /// </summary>
        /// <param name="numberEnemies"> it uses field prop indirectly </param>
        /// <returns> array of 2 elements presenting the x and y coordinate </returns>
        private int[] RandomEnemyCoordinateGenerator(int numberEnemies)
        {
            return new int[2];
        }

        /// <summary>
        /// generates random number presenting the enemies needed to be generated on the field
        /// </summary>
        /// <returns> Returns the number of enemies that needs to spawn </returns>
        private int RandomNumberEnemeyGenerator()
        {
            Random rand = new Random();
            return rand.Next(14, 24);
        }

        /// <summary>
        /// Generates how much towers the field should display
        /// </summary>
        /// <returns></returns>
        private int RandomTowerNumberGenerator()
        {
            Random rand = new Random();
            return rand.Next(20, 27);
        }

        /// <summary>
        /// Generates Random Tower Coordinates
        /// </summary>
        /// <param name="field"></param>
        /// <param name="previousCoordinates"></param>
        /// <returns> returns a string of x and y coordinate of tower which si added to the collection hashset</returns>
        private string RandomTowerCoordinateGenerator(char[,]field,HashSet<string> previousCoordinates)
        {
            int[] coordinates = new int[2];

            do
            {
                coordinates[0] = RandomNumberGenerator(7, field.GetLength(0) - 2);
                coordinates[1] = RandomNumberGenerator(1, field.GetLength(1) - 7);
            } while (coordinates[0] == coordinates[1] && !previousCoordinates.Contains(coordinates[0] + " " + coordinates[1]));

            return coordinates[0] + " " + coordinates[1];
        }

        private int RandomNumberGenerator(int min, int max)
        {
            Random current = new Random();
            return current.Next(min, max) % max;
        }




        /// <summary>
        /// Function that calls the main menue its the first function called in the program
        /// </summary>
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


        //------------------------------------------------------------------------------------------
        
    }
}
