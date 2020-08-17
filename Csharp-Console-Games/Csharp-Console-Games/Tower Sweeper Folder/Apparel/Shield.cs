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
                if(value<=0 || armour>150)
                {
                    throw new ArgumentException("Invalid Shield Value");
                }
                else
                {

                }
            }
            get { return this.armour; }
        }


        //behaviour
        protected void Hit(int damageReceived)
        {

        }


            

    }
}
