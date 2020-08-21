using Csharp_Console_Games.Tower_Sweeper_Folder;
using Csharp_Console_Games.Tower_Sweeper_Folder.Apparel;
using Csharp_Console_Games.Tower_Sweeper_Folder.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public abstract class Enemy
    {
        //consts
        private const int DefaultHeathPoints = 100;   //on startup
        private const int DefaultManaPoints = 150;    //on startup
        protected const char DefaultAboveHalfHPVisualSigniture = 'E'; //when above half HP
        protected const char DefaultBelowHalfHpSignature = 'e'; 
        private StringBuilder sb = new StringBuilder();

        // fields
        protected string name;
        protected char visualSignature;
        protected char[][] fieldOn;
        protected char currentSymbolOn;       // needed for movement
        protected int health;
        protected int healthRange;
        protected int mana;
        protected int manaRange;
        protected int overallDamage;
        protected int xCoordinate;
        protected int yCoordinate;
        protected Shield currentShield;
        protected Weapon currentWeapon;
        protected List<Item> items;   
        protected List<Spell> spells;

        //constructor 
        public Enemy(string name,int x, int y,char[][] field,int manaRange,int healthRange,Shield shield,Weapon weapon)
            :this(manaRange,healthRange,shield,weapon)
        {
            this.RowCoordinate = x;
            this.ColCoordinate = y;
            this.fieldOn = field;
            this.Name = name;
            this.DecideStartingCurrentSymbol();

        }

        private Enemy(int manaRange, int healthRange, Shield shield, Weapon weapon) : this()        //on creation
        {
            this.ManaRange = manaRange;
            this.HealthRange = healthRange;

            if(!(shield is null))
            {
                this.currentShield = shield;
            }
           
            if(!(weapon is null))
            {
                this.currentWeapon = weapon;
            }
            
        }

        private Enemy()
        {
            this.visualSignature = DefaultAboveHalfHPVisualSigniture;
            this.items = new List<Item>(10);
            this.spells = new List<Spell>(3);
            this.currentShield = null;
            this.currentWeapon = null;

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

        protected bool isAbilityAvailable
        {
            
            set
            {
                this.sb.Clear();
                for(int i =0;i<this.spells.Count;i++)
                {
                    if(this.Mana>=this.spells[i].ManaCost)
                    {
                        this.sb.Append(i + " ");
                    }
                }

      
            }
            get 
            {
                int[] tempSpellsAvailable;
                tempSpellsAvailable = this.sb.ToString().Trim().Split(" ").Select(int.Parse).ToArray();
                if(tempSpellsAvailable.Length>0)
                {
                    this.CurrentAvailableAbilites = tempSpellsAvailable;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public int Damage => this.overallDamage;
        

        private int[] CurrentAvailableAbilites { set; get; }        //cant remember why I used this 
        

        //Behaviour

        public void Patrol()        //this decides direction and MovementExecutes it 
        {
            string direction = null;
            while (this.Health > 0)
            {
                if (this.fieldOn.Length - this.ColCoordinate > 35)
                {
                    direction = "left";
                }
                else
                {
                    direction = "right";
                }
                this.fieldOn[this.RowCoordinate][this.ColCoordinate] = this.currentSymbolOn;
                this.Move(direction);

            }


        }

        protected void Move(string direction)         //Linked with patrol
        {
            switch(direction)
            {
                case "right":
                    this.currentSymbolOn = this.fieldOn[this.RowCoordinate][this.ColCoordinate + 1];
                    this.ColCoordinate++;
                    this.fieldOn[this.RowCoordinate][this.ColCoordinate] = this.VisualiseOnField;
                    break;

                case "left":
                    this.currentSymbolOn = this.fieldOn[this.RowCoordinate][this.ColCoordinate - 1];
                    this.ColCoordinate--;
                    this.fieldOn[this.RowCoordinate][this.ColCoordinate] = this.VisualiseOnField;
                    break;
            }
        }

        protected void Attack()
        {
            if(this.isAbilityAvailable)     //when creating the abilities modify this to work with range as well
            {
                this.UseAbility();
            }
            else
            {
                this.Attack();
            }
        }

        protected void ScanArrea(string direction)      //directio might be the direction the enemy is facing
        {

        }

        protected void ChasePlayer()
        {

        }

        protected void UseAbility()
        {

        }

        public void IncreaseHealth(int increaseBy)
        {
            if(this.Health+increaseBy<=800)
            {
                if (this.Health <= this.HealthRange / 2 && this.Health + increaseBy > this.HealthRange / 2)
                {
                    this.visualSignature = 'E';
                    this.Health += increaseBy;
                }
            }
           
        }

        public void DecreaseDamage(int decreaseBy)
        {
            if (this.Health - decreaseBy <= 0)
            {
                return;
            }
            else
            {
                if (this.Health - decreaseBy <= this.HealthRange / 2)
                {
                    this.visualSignature = DefaultBelowHalfHpSignature;
                    this.Health -= decreaseBy;
                    return;
                }

                this.Health -= decreaseBy;

            }

            
           
        }

        public void IncreaseDamage(int increaseBy)
        {
            this.overallDamage += increaseBy;
        }

        private void DecideStartingCurrentSymbol()     //on creation
        {
            this.currentSymbolOn= this.fieldOn[this.RowCoordinate][this.ColCoordinate];
        }
    }
}
