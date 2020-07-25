using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Buildings
{
   public class Floor
    {
        //consts 
        private bool DefaultBeatenFloorValue = false;

        //resources
        private StringBuilder sb;
        private HashSet<string> enemyCoordinatesOnFloor;
        private HashSet<string> chestCoordinatesOnFloor;

        //field
        private bool isFloorBeaten;
        private int floorCount;
        private char[,] floorField;
        private Dictionary<string, Enemy> currentEnemeisOnFloor;
        //private Dictionary<string, Chest> currentChestsOnFloor;
        private int[,] floorExit;
        private int[,] nextFloor;
       // Player thePlayerOnTheFloor;     //not sure if it has to be like this 

        //construtos
        public Floor(int floorCount): this()
        {
            this.floorCount = floorCount;

        }

        private Floor()
        {
            //generate the floor rows and columns
            this.floorField = new char[RandomNumberGenerator(11,18),RandomNumberGenerator(14,17)];

            //initialise  fields
            this.currentEnemeisOnFloor = new Dictionary<string, Enemy>();
            this.isFloorBeaten = DefaultBeatenFloorValue;

            //initialise stuff from resources
            this.sb = new StringBuilder();
            this.enemyCoordinatesOnFloor = new HashSet<string>();
            this.chestCoordinatesOnFloor = new HashSet<string>();

            
        

            //Spawn Enemies,Chests,Prepare Floor field
            this.CreateFloor();     //creates floor and spawns chests and enemies;
        }


        //properties
        private string FloorField
        {
            set
            {
                this.sb.Clear();
                for(int i =0;i<this.floorField.GetLength(0);i++)
                {
                    for(int j=0;j<this.floorField.GetLength(1);j++)
                    {
                        this.sb.Append(this.floorField[i, j]);
                    }
                    this.sb.Append(Environment.NewLine);
                }
            }

            get { return this.sb.ToString(); }
        }

        public bool IsFloorBeaten => this.isFloorBeaten;

        
        

        



        //BEHAVIOUR

        //create floor on startup
        private void CreateFloor()
        {
            for(int i =0;i<this.floorField.GetLength(0);i++)
            {
                for(int j =0;j<this.floorField.GetLength(1);j++)
                {
                    this.floorField[i, j] = '.';
                }

            }
            this.AddExitAndNextOnFloor();
            this.SpawnEnemiesOnFloor();
            this.SpawnChestsIfNeeded();
        }


        public void DisplayFloorOnScreen()
        {
            this.FloorField = "Hello World";
            Console.WriteLine(this.FloorField);
        }

        private void AddExitAndNextOnFloor()
        {
            this.floorField[0, 0] = '+';
            this.floorField[this.floorField.GetLength(0) - 1, 0] = '-';
        }

        private void SpawnEnemiesOnFloor()      //implement
        {
            this.GenerateEnemyCoordinates();
            int[] getCoordinatesFromString;
            foreach(var item in  this.enemyCoordinatesOnFloor)
            {
                getCoordinatesFromString = item.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                this.floorField[getCoordinatesFromString[0], getCoordinatesFromString[1]] = 'E';
            }

        }

        private void GenerateEnemyCoordinates()     //MODIFIY TO WORK WITH OBJECT ENEMY
        {
            int numberEnemies = GenerateNumberEnemies();

            int rowCoordinate=0;
            int colCoordinate=0;

            for(int i =0;i<numberEnemies;i++)
            {
                do
                {
                    rowCoordinate = this.RandomNumberGenerator(2, this.floorField.GetLength(0) - 2);
                    colCoordinate = this.RandomNumberGenerator(0, this.floorField.GetLength(1) - 1);
                    
                }
                while (this.enemyCoordinatesOnFloor.Contains(rowCoordinate+" "+colCoordinate));

                this.enemyCoordinatesOnFloor.Add(rowCoordinate + " " + colCoordinate);
            }
        }

        private int GenerateNumberEnemies()
        {
            return RandomNumberGenerator(4, 7);
        }

        private void SpawnChestsIfNeeded()      //implement
        {
            int numberChests = this.GenerateNumberChestsOnField();
            switch(numberChests)
            {
                case 0: break;
                default:
                    int rowCoordinates=0;
                    int colCoordinates=0;
                    for(int i =0;i<numberChests;i++)
                    {
                        do
                        {
                            rowCoordinates = this.RandomNumberGenerator(2, this.floorField.GetLength(0) - 2);
                            colCoordinates = this.RandomNumberGenerator(0, this.floorField.GetLength(1) - 1);
                        }
                        while (this.chestCoordinatesOnFloor.Contains(rowCoordinates+" "+colCoordinates)
                         && this.enemyCoordinatesOnFloor.Contains(rowCoordinates+" "+colCoordinates));

                        this.chestCoordinatesOnFloor.Add(rowCoordinates + " " + colCoordinates);
                    }

                    int[] chestCoordinatesTransformed;
                    foreach(var item in this.chestCoordinatesOnFloor)
                    {
                        chestCoordinatesTransformed = item.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();
                        this.floorField[chestCoordinatesTransformed[0], chestCoordinatesTransformed[1]] = '$';      // make it like the towers


                    }
                    break;
                    
            }
        }

       


        //TO DO implement player statas such as luck and so on that play role in spawning items and chests
        private int GenerateNumberChestsOnField()
        {
            return this.RandomNumberGenerator(0, 1);
        }




        //helping methods

        //random number generator
        private int RandomNumberGenerator(int min, int max)
        {
            Random current = new Random();
            return current.Next(min, max) % max;
        }

    }
}
