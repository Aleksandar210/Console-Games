using Csharp_Console_Games.Tower_Sweeper_Folder;
using Csharp_Console_Games.Tower_Sweeper_Folder.Apparel;
using Csharp_Console_Games.Tower_Sweeper_Folder.Weapons;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Transactions;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public class Player
    {

        //resources
        StringBuilder sb;

        //related to movement
        private char drawAfterPlayer;           //the symbol behind us when we moved
        private int[] coordinatesDrawAfter;     //where to draw the symbol after the step
        

        //consts
        private const int DefaultHeathPoints = 100;   //on startup
        private const int DefaultManaPoints = 150;    //on startup
        private const int StartingPositionRowNewGame = 19;
        private const int StartingPositionColNewGame = 35;
        private const int StartingPositoonRowOnRoom = 0;    //on each room spawn
        private const int StartingPositonColRoom = 0;       //on each room spawn

        // fields
        private string name;
        private int[] positonOnField;       //position on the field or in the room
        private int overallDamage;
        private int health;
        private int healthRange;
        private int mana;
        private int manaRange;
        private List<Item> items;
        private Spell[] spells;
        private Shield currentShield;
        private Weapon rightHandWeapon;
        private char[][] playerEnvironement;
        private bool hasApparel;
        protected int clearedTowers;
     
        //constructors
        public Player(string name,int mana,int health):this(name)
        {
            this.ManaRange = mana;
            this.HealthRange = health;
            this.sb = new StringBuilder();

        }

        public Player(string name,int currentMana,int currentHealth,Shield currentShield,Weapon currentWeapon)     //this will be used for loading the files
        {

        }

        private Player(string name) : this()
        {
            this.Name = name;
            this.positonOnField = new int[2] { StartingPositionRowNewGame, StartingPositionColNewGame };
            
        }



        private Player()
        {
            this.drawAfterPlayer = '.';
            this.coordinatesDrawAfter = new int[2] { this.positonOnField[0],this.positonOnField[1]};
            this.items = new List<Item>();
            this.spells = new Spell[4];
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
                            this.mana+= value;
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
                if(value<=0 || value>800)
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

        public char[][] PlayerEnvironment => this.playerEnvironement;

        public int ClearedTowers => this.clearedTowers;
       
        //behaviour

        private Func<char, char[][],char> DecideDrawAfterWhatToBe = (futureChar, field) =>
          {
              switch(futureChar)
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
              }

              return '.';
          };

        private Func<char, bool> CheckIfItsEntrance = (pos) =>
          {
              switch (pos)
              {
                  case '+':
                      return true;
                      break;
                  default:
                      return false;
                      break;
              }
          };

        public void Move(string direction)          //bind key (means will execute upon presing certain key)
        {
            
            switch(direction.ToLower())     //modfigy for index out of range on the field with try catch
            {
                case "forward":
                    if(this.CheckIfItsEntrance(playerEnvironement[this.positonOnField[0]+1][this.positonOnField[1]]))
                    {
                        //execute entering tower;
                    }
                    else
                    {
                        this.coordinatesDrawAfter[0] = this.positonOnField[0];
                        this.coordinatesDrawAfter[1] = this.positonOnField[1];
                        this.DecideDrawAfterWhatToBe(playerEnvironement[this.positonOnField[0] - 1][ this.positonOnField[1]]
                            , playerEnvironement);
                        this.positonOnField[0]--;
                       
                    }
                    break;

                case "backward":
                    if (this.CheckIfItsEntrance(playerEnvironement[this.positonOnField[0] + 1][this.positonOnField[1]]))
                    {
                        //execute entering tower;
                    }
                    else
                    {
                        this.coordinatesDrawAfter[0] = this.positonOnField[0];
                        this.coordinatesDrawAfter[1] = this.positonOnField[1];
                        this.DecideDrawAfterWhatToBe(playerEnvironement[this.positonOnField[0] + 1][this.positonOnField[1]]
                            , playerEnvironement);
                        this.positonOnField[0]++;

                    }

                    break;

                        case "left":
                    if (this.CheckIfItsEntrance(playerEnvironement[this.positonOnField[0] + 1][this.positonOnField[1]]))
                    {
                        //execute entering tower;
                    }
                    else
                    {
                        this.coordinatesDrawAfter[0] = this.positonOnField[0];
                        this.coordinatesDrawAfter[1] = this.positonOnField[1];
                        this.DecideDrawAfterWhatToBe(playerEnvironement[this.positonOnField[0]][this.positonOnField[1]-1]
                            , playerEnvironement);
                        this.positonOnField[1]--;

                    }
                    break;

                case "right":
                    if (this.CheckIfItsEntrance(playerEnvironement[this.positonOnField[0] + 1][this.positonOnField[1]]))
                    {
                        //execute entering tower;
                    }
                    else
                    {
                        this.coordinatesDrawAfter[0] = this.positonOnField[0];
                        this.coordinatesDrawAfter[1] = this.positonOnField[1];
                        this.DecideDrawAfterWhatToBe(playerEnvironement[this.positonOnField[0]][this.positonOnField[1]+1]
                            , playerEnvironement);
                        this.positonOnField[1]++;

                    }
                    break;
            }
        }

        public void SetCurrentPositonOnRoomSpawn()
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

        public void EquipShield(Shield desiredShield)   //may need to figure out how to return to field dispaly later on 
        {
            int answer = -1;
            if(this.hasApparel)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Are you sure you want to equip {desiredShield} over {this.currentShield}");
                    Console.WriteLine("1|YES");
                    Console.WriteLine("2|NO");
                    Console.WriteLine("3|Put in bag");
                    Console.Write("Enter answer: ");
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            this.currentShield = desiredShield;
                            break;
                        case 2:
                            break;
                        case 3:
                           //implement bag
                            break;
                    }

                }
                while (answer == 1 || answer == 2);

               
            }
            else
            {
                this.currentShield = desiredShield;
            }
        }

        public void DecreaseHP(int decreaseBy)     // if player takes damage
        {
            if(this.Health-decreaseBy<=0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= decreaseBy;
            }
            
        }

        public void IncreaseHP(int increaseBy)        // if player uses a potion
        {
            this.Health = increaseBy;

        }

        public void IncreaseDamage(int increaseBy)
        {
            this.overallDamage += increaseBy;
        }

        public void UpdatePlayerEnvironement(char[][] currentSurroundings)          //NOT SURE WHY
        {
            this.playerEnvironement = currentSurroundings;
        }

        public override string ToString()
        {
            this.sb.Clear();
            this.sb.Append("|" + this.Name + "|"+Environment.NewLine);
            this.sb.Append($"Health: {this.Health}/{this.HealthRange}"+Environment.NewLine);
            this.sb.Append($"Mana: {this.Mana}/{this.ManaRange}"+Environment.NewLine);
            if (this.hasApparel)
            {
                this.sb.Append(this.currentShield+Environment.NewLine);
            }
            if (this.items.Count > 0)
            {
                sb.Append($"{this.items.Count}-Items"+Environment.NewLine);
                for(int i =0;i<this.items.Count;i++)
                {
                    if (i % 5 == 0)
                    {
                        this.sb.Append(Environment.NewLine);
                    }
                    this.sb.Append(this.items[i] + " ");
                }
            }
            else
            {
                this.sb.Append("No Items currently." + Environment.NewLine);
            }

            if(this.rightHandWeapon is null)
            {
                this.sb.Append("No weapon in hand"+Environment.NewLine);
            }
            else
            {
                this.sb.Append(this.rightHandWeapon + Environment.NewLine);
            }
            this.sb.Append("Spells:");
            foreach(var item in this.spells)
            {
                this.sb.Append(" " + item.Name);
            }
            
            return sb.ToString();
        }
    }
}
