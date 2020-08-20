using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Weapons
{
    public abstract class Weapon
    {


        //fields
        private int damage;
        private int durability;
        private string name;

        //costructs
        public Weapon(string name,int damage, int durability)
        {

        }

        //properties
        protected int Damage
        {
            set
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

        protected string Name
        {
            set
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

        //behaviour
    }
}
