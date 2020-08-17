using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    public abstract class Shield
    {
        //consts
        private const int DefaultArmour = 1;
        private const string DefaultName = "602";
        //fields
        protected string name;
        protected int armour;

        //constructors

        public Shield(string name,int armour):this()
        { 

        }

        public Shield()
        {
            
        }

        //properties
        protected int Armour
        {
            set
            {
                if(value<=0 || value>150)
                {
                    throw new ArgumentException("Invalid Shield Value");
                }
                else
                {
                    this.armour = value;
                }
            }
            get { return this.armour; }
        }

        protected string Name
        {
            set
            {
                if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Name I guess");
                }
                else
                {
                    this.name = value;
                }
            }
            get { return this.name; }
        }


        //behaviour
        protected void Hit(int damageReceived)
        {

        }

        protected abstract void EffectOnHit();  //this executes some action from class ShieldEffects

    }
}
