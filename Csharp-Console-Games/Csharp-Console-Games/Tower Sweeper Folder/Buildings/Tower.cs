using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Buildings
{
   public class Tower
    {
        //consts
        private const int DefaultWidth = 5;
        private const int DefaultHeight = 5;
        private const int DefaultEnemiesCount = 0;

        //fields
        private string name;
        private int enemieCount;
        private Dictionary<string, Enemy> enemiesInsideTower;

        public Tower(string name):this()
        {
            this.Name = name;

        }

        public Tower()
        {
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




    }
}
