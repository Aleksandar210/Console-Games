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
        private const int DefualtCurrentFoorAtValue = 1;
        private const bool DefaultTowerBeatenValue = false;

        //fields
        private string name;
        private Floor[] currentFloors;
        private int floorCount;
        private int currentFloorAt;
        private bool isTowerBeaten;
       
        

        public Tower(string name):this()
        {
            this.Name = name;
           
        }

        public Tower()
        {
            this.floorCount = this.RandomNumberGenerator(5, 7);
            this.currentFloors = new Floor[this.floorCount];
            this.isTowerBeaten = DefaultTowerBeatenValue;
            this.currentFloorAt = DefualtCurrentFoorAtValue;
            this.GenerateFloors();
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

      
        private int CurrentFloorAt
        {
            get { return this.currentFloorAt - 1; }
        }

        public bool IsTowerBeaten
        {
            set     //implement when to make true
            {

            }

            get { return this.isTowerBeaten; }
            
               
            
        }


       


        //BEHAVIOUR


            //generate floors and add them to the collection 
        private void GenerateFloors()
        {
           for(int i =0;i<this.floorCount;i++)
           {
                this.currentFloors[i] = new Floor(i + 1);
           }


        }

        //Helping Methods

        //random number generator
        private int RandomNumberGenerator(int min, int max)
        {
            Random current = new Random();
            return current.Next(min, max) % max;
        }

       


    }
}
