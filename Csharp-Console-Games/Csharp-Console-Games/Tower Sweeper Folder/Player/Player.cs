using Csharp_Console_Games.Tower_Sweeper_Folder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public class Player
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
        
     
        //constructors
        public Player(string name,int mana,int health):this(name)
        {
            this.ManaRange = mana;
            this.HealthRange = health;

        }

        public Player(string name) : this()
        {
            this.Name = name;
        }

        public Player()
        {
            this.items = new List<Item>();
            this.spells = new List<Spell>();
            this.Health = DefaultHeathPoints;
            this.Mana = DefaultManaPoints;
        }


        //properties
        public string Name
        {
            private set
            {
                if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                else
                {
                    this.name = value;
                }
            }
            get { return this.name; }
        }

        public int Health
        {
            
            private set
            {
                if(value>0 && value<=800)
                {
                    switch (this.health)
                    {
                        case 0:
                            this.health += value;
                            break;
                        default:
                            int neededHealth = this.HealthRange - this.health;
                            if(value>=neededHealth)
                            {
                                this.health = this.healthRange;
                            }
                            else if(value<neededHealth)
                            {
                                this.health += value;
                            }
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException("Health out of range or below it!");
                }

            }

            get { return this.health; }
        }

        private int HealthRange
        {
            set
            {
                if(value<=0 || value>800)
                {
                    throw new ArgumentException("Invalid Health Range [0-800]");
                }
                else
                {
                    this.healthRange = value;
                }
            }
            get { return this.HealthRange; }
        }

        public int Mana
        {
            private set
            {

            }
            get { return this.mana; }
        }

        public int ManaRange
        {
            private set
            {
                if(value<=0 || value>700)
                {
                    throw new ArgumentException("Invalid mana range [0-700]");
                }
                else
                {
                    this.manaRange = value;
                }
            }
            get { return this.manaRange; }
        }

        //behaviour
        public void Move()          //bind key (means will execute upon presing certain key)
        {

        }

        public void Attack()        //bind key
        {

        }

        public void SelectItem()    //bind key
        {

        }

        public void UseItem()       //the selected Item
        {

        }

        public void UseSpell()     // bind key
        {

        }

        public void DecreaseHP()     // if player takes damage
        {

        }

        public void IncreaseHP()        // if player uses a potion
        {

        }

    }
}
