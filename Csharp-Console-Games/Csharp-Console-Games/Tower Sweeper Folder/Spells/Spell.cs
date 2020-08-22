using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public abstract class Spell
    {
        //consts
        private const int DefaultDamage = 0;
        private const int DefaultManaCost = 0;
        private const int DefaultHealthRestoration = 0;
        private const int DefaultManaRestoration = 0;
        
        

        //fields
        protected string type;
        protected string name;
        protected int damage;
        protected int healthRestoration;
        protected int manaRestoration;
        protected int manaCost;

        //constructors


        //properties
        public int ManaCost
        {
            private set
            {

            }

            get { return this.manaCost; }
        }


        public string Name
        {
            private set
            {

            }

            get { return this.name; }
        }
    }
}
