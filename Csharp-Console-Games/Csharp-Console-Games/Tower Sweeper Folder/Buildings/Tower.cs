using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Buildings
{
   public class Tower
    {
        //resources
        StringBuilder sb;

        //consts 
        private const int DefaultEnemiesCount = 0;
        private const int DefaultNumberFloors = 0;

        //fields
        private string name;
        private Dictionary<int, char[,]> currentFloors;
        private int enemieCount;
        private int floorCount;
       //private Dictionary<string, Chest> chestsInTheTower;        //TO DO implement chest class and logic
        private Dictionary<string, Enemy> enemiesInsideTower;

        public Tower(string name):this()
        {
            this.Name = name;
            this.currentFloors = new Dictionary<int, char[,]>();
            this.enemieCount = this.RandomNumberGenerator(5,8);     //generates number of enemies

        }

        public Tower()
        {
            this.sb = new StringBuilder();
            this.enemieCount = DefaultEnemiesCount;
            this.enemiesInsideTower = new Dictionary<string, Enemy>();
        }


        //properties
        public string Name
        {
            private set
            {
                if(String.IsNullOrEmpty(value)|| String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");

                }
                else
                {
                    this.name = value;

                }
            }
            get { return this.name; }
        }


        private string Floor
        {
            set
            {
                this.sb.Clear();

            }

            get { return " "; }
        }


        //BEHAVIOUR


            //generate flor
        private void GenerateFloor()
        {

        }

        //Helping Methods

        //random number generator
        private int RandomNumberGenerator(int min, int max)
        {
            Random current = new Random();
            return current.Next(min, max) % max;
        }

        private int RandomFloorEnemyCountGenerator()
        {
            int[] coordinates = new int[2];

            do
            {
                coordinates[0] = RandomNumberGenerator(7, field.GetLength(0) - 2);
                coordinates[1] = RandomNumberGenerator(1, field.GetLength(1) - 7);
            } while (coordinates[0] == coordinates[1] && !previousCoordinates.Contains(coordinates[0] + " " + coordinates[1]));

            return coordinates[0] + " " + coordinates[1];
        }


    }
}
