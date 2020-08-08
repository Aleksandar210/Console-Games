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
        private char currentSymbolOn;       // needed for movement
        private int firstMovement = -1;
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
            this.RowCoordinate = x;
            this.ColCoordinate = y;
            this.fieldOn = field;
            this.Name = name;
            this.DecideStartingCurrentSymbol();

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

        public int Health
        {

            private set
            {
                if (value > 0 && value <= 800)
                {
                    switch (this.health)
                    {
                        case 0:
                            this.health += value;
                            break;
                        default:
                            int neededHealth = this.HealthRange - this.health;
                            if (value >= neededHealth)
                            {
                                this.health = this.healthRange;
                            }
                            else if (value < neededHealth)
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
                if (value <= 0 || value > 800)
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
                if (value <= 0 || value > 800)
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
                this.xCoordinate = value;
            }
            get { return this.xCoordinate; }
        }

        private int ColCoordinate
        {
            set
            {
                this.yCoordinate = value;
            }

            get { return this.yCoordinate; }
        }

        public char VisualiseOnField => 'E';

        //Behaviour

        private Func<char, char[][], char> DecideDrawAfterWhatToBe = (futureChar, field) =>
        {
            switch (futureChar)
            {
                case '.':
                    return '.';
                    break;
                case 'E':
                    return '.';
                    break;
                case '_':
                    return '_';
                    break;
                case '-':
                    return '-';
                    break;
                case '|':
                    return '|';
                    break;
                case '+':
                    return '+';
                    break;
            }

            return '.';
        };

        public void Patrol()        //this decides direction and MovementExecutes it 
        {
            string direction = null;
            while(this.Health>0)
            {
                if (this.fieldOn.Length - this.ColCoordinate > 35)
                {
                    direction = "left";
                }
                else
                {
                    direction = "right";
                }
                this.Move();
            }


        }

        private void Move()         //Linked with patrol
        {

        }

        private void DecideStartingCurrentSymbol()     //on creation
        {
            this.currentSymbolOn= this.fieldOn[this.RowCoordinate][this.ColCoordinate];
        }
    }
}
