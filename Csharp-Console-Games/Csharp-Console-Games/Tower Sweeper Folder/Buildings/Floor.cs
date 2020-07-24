using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Buildings
{
   public class Floor
    {
        //resources
        private StringBuilder sb;
        private HashSet<string> enemyCoordinatesOnFloor;
        private HashSet<string> chestCoordinatesOnFloor;

        //field
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
            this.floorField = new char[RandomNumberGenerator(7,14),RandomNumberGenerator(10,14)];

            //initialise  fields
            this.currentEnemeisOnFloor = new Dictionary<string, Enemy>();

            //initialise stuff from resources
            this.sb = new StringBuilder();
            this.enemyCoordinatesOnFloor = new HashSet<string>();
            this.chestCoordinatesOnFloor = new HashSet<string>();
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



        //helping methods

        //random number generator
        private int RandomNumberGenerator(int min, int max)
        {
            Random current = new Random();
            return current.Next(min, max) % max;
        }

    }
}
