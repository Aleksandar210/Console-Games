using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Buildings
{
   public class Tower
    {
        //resources
       

        //consts 
        private const int DefaultEnemiesCount = 0;
        private const int DefaultNumberFloors = 0;

        //fields
        private string name;
        private Dictionary<int, char[,]> currentFloors;
        private int floorCount;
       
        

        public Tower(string name):this()
        {
            this.Name = name;
            
          

        }

        public Tower()
        {
            this.currentFloors = new Dictionary<int, char[,]>();
            this.floorCount = this.RandomNumberGenerator(5, 7);
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


       


        //BEHAVIOUR


            //generate flor
        private void GenerateFloor()
        {
            //char[,] currentFloor = new char[,];       //generate the floor with object
        }

        //Helping Methods

        //random number generator
        private int RandomNumberGenerator(int min, int max)
        {
            Random current = new Random();
            return current.Next(min, max) % max;
        }

        //generates coordinates of enemies on the floor 
        private string RandomFloorEnemyCoordinatesCountGenerator(char[,] field,HashSet<string> previousCoordinates)
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
