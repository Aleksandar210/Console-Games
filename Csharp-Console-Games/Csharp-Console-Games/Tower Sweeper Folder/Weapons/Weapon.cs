using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Weapons
{
    public abstract class Weapon
    {
        //resource
        protected Random rand;
      
        //fields
        protected int damage;
        protected readonly int durabilityRange;       //this is the constant range
        protected int currentDurabilityValue;       //this is changable
        protected string name;
        protected string type;      //optional or not implemented for now will do in future time


        //costructs
        public Weapon(string name,int damage, int durability):this()
        {
            this.Name = name;
            this.Damage = damage;
            this.DurabilityRange = durability;
        }

        private Weapon()
        {
            this.rand = new Random();
            
        }

        //properties
        public int Damage
        {
           private set
            {
                if(value<=0 || value >110)
                {
                    throw new ArgumentException("Invalid damage value");
                }
                else
                {
                    this.damage = value;
                }
            }

            get { return this.damage; }
        }

        public string Name
        {
           private set
            {
                if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid name");
                }
                else
                {
                    this.name = value;
                }
            }

            get { return this.name; }
        }

        public int DurabilityRange
        {
           private set
            {
                if(value<=0 || value>100)
                {
                    throw new ArgumentException("Invalid Durability value");
                }
            }


            get { return this.durabilityRange; }
        }

        public int CurrentDurabilityValue => this.currentDurabilityValue;

        //behaviour

        protected void DereaseCurrentDurabilityOnHit()
        {
            int decreaseBy = rand.Next(2, 5);
            this.currentDurabilityValue -= decreaseBy;
        }

        protected void FixWeaponDurabilityValue(int fixBy)
        {
            if(this.currentDurabilityValue+ fixBy<=this.DurabilityRange)
            {
                this.currentDurabilityValue += fixBy;
            }
            else
            {
                this.currentDurabilityValue = this.DurabilityRange;
            }
        }

        public override string ToString()
        {
            string info = $"Name: {this.Name}, Type: {this.type}, Damage: {this.Damage}, Durability: {this.CurrentDurabilityValue}/{this.DurabilityRange}";
            return info;
        }
    }
}
