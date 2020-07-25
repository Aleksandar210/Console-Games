

using Csharp_Console_Games.Tower_Sweeper_Folder.Buildings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    class Engine
    {
        //usable resoures
        private readonly StringBuilder sb;
        private HashSet<string> towerCoordiantes;
        private HashSet<string> enemiesCoordiantes;


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
        private Tower currentTowerIn;
        private char[,] field;

        //contructors
        public Engine()
        {
            this.towerCoordiantes = new HashSet<string>();
            this.enemiesCoordiantes = new HashSet<string>();
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
        private string Room         //thi displays the room inside the tower
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

            //adding coordinates of towers on the field     //to do create towers to add in dictioanary as well
            for (int i = 0; i < numberTowersTheFiledHas; i++)
            {
                this.towerCoordiantes.Add(RandomTowerCoordinateGenerator(this.field, this.towerCoordiantes));
                
            }


            for (int i=0;i<this.field.GetLength(0);i++)
            {
                for(int j =0;j<this.field.GetLength(1);j++)
                {
                    this.field[i, j] = '.';
                }
            }

            foreach(var item in this.towerCoordiantes)
            {
                this.BuildTower(this.field, item.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray());
            }



        }

        
        /// <summary>
        ///generates coordinates for a tower randomyl and within range
        /// </summary>
        /// <param name="numberEnemies"> it uses field prop indirectly </param>
        /// <returns> array of 2 elements presenting the x and y coordinate </returns>
        private string RandomEnemyCoordinateGenerator(int numberEnemies,HashSet<string> previousCoordinates
            ,HashSet<string> previousTowerCoordinates)
        {
            int[] coordinates = new int[2];

            do
            {
                coordinates[0] = RandomNumberGenerator(1, field.GetLength(0) - 1);
                coordinates[1] = RandomNumberGenerator(0, field.GetLength(1) - 1);
            } while (coordinates[0] == coordinates[1] && (!previousCoordinates.Contains(coordinates[0] + " " + coordinates[1])
            && !previousTowerCoordinates.Contains(coordinates[0]+" "+coordinates[1])));

            return coordinates[0] + " " + coordinates[1];
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

        private  void BuildTower(char[,] field, params int[] coordinates)
        {
            //sdies and tops bott draw
            int counterSides = coordinates[0];
            int counterTopsBottoms = coordinates[1];
            for (int i = 0; i < 5; i++)
            {
                field[coordinates[0], counterTopsBottoms] = '_';
                field[coordinates[0] - 4, counterTopsBottoms] = '-';
                counterTopsBottoms++;
            }
            for (int i = 0; i < 5; i++)
            {
                field[coordinates[0], coordinates[1]] = '|';
                field[coordinates[0], coordinates[1] + 5] = '|';
                coordinates[0]--;
            }

            field[coordinates[0], coordinates[1]] = '+';
            
        }

        private void SpawnEnemies(char[,] field,HashSet<string> previousEnemyCoordinates)
        {
            
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

        public void PlayTowerSepper()
        {
            while(this.numberTowerSweeped!=this.numberTowersOnTheField)
            {
                this.DisplayFieldOnScreen();        //displays field on screen  refreshes afte player or enemy movements
                                                    //waits for player movement

            }
        }


        //implement logic  implement past symbol currentSymbol so on
        private void ControlPlayer()
        {
           
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.LeftArrow:
                        
                        return;
                    case ConsoleKey.UpArrow:
                        this.player.Move()
                        break;
                    case ConsoleKey.DownArrow:
                        
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
