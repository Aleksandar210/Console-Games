using Csharp_Console_Games.Tower_Sweeper_Folder;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public class Enemy
    {
        //consts
        private const int DefaultHeathPoints = 100;   //on startup
        private const int DefaultManaPoints = 150;    //on startup
        private const char DefaultVisualSigniture = 'E'; //aways

        // fields
        private string name;
        private char visualSignature;
        private char[][] fieldOn;
        private int health;
        private int healthRange;
        private int mana;
        private int manaRange;
        private int xCoordinate;
        private int yCoordinate;
        private List<Item> items;   
        private List<Spell> spells;

        //constructor 
        public Enemy(string name,int x, int y,char[][] field):this()
        {
            this.fieldOn = field;
            this.Name = name;

        }

        private Enemy()
        {
            this.visualSignature = DefaultVisualSigniture;
            this.items = new List<Item>(10);
            this.spells = new List<Spell>(3);

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

        public int Mana
        {
            private set
            {

                switch (this.mana)
                {
                    case 0:
                        this.mana += value;
                        break;
                    default:
                        int neededMana = this.ManaRange - this.mana;
                        if (value >= neededMana)
                        {
                            this.health = this.healthRange;
                        }
                        else if (value < neededMana)
                        {
                            this.mana += value;
                        }
                        break;
                }

            }

            get { return this.mana; }

        }

        private int ManaRange
        {
            set
            {
                if (value <= 0 || value > 700)
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

        private int RowCoordinate
        {
            set
            {
             if((value<this.fieldOn.Length-3 || value>-1))   
            }
        }


    }
}
