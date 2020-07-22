using Csharp_Console_Games.Tower_Sweeper_Folder;

using System;
using System.Collections.Generic;
using System.Text;


namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public class Enemy
    {
        //consts
        private const int DefaultHeathPoints = 100;   //on startup
        private const int DefaultManaPoints = 150;    //on startup

        // fields
        private string name;
        private int health;
        private int healthRange;
        private int mana;
        private int manaRange;
        private List<Item> items;   
        private List<Spell> spells;

        //constructor 
        public Enemy(string name)
        {

        }

        //properties
        public string Name
        {
            private set
            {
                if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty or null");
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
