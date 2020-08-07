using Csharp_Console_Games.Tower_Sweeper_Folder;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Transactions;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public class Player
    {
        //related to movement
        private char drawAfterPlayer;           //the symbol behind us when we moved
        private int[] coordinatesDrawAfter;     //where to draw the symbol after the step
        

        //consts
        private const int DefaultHeathPoints = 100;   //on startup
        private const int DefaultManaPoints = 150;    //on startup
        private const int StartingPositionRowNewGame = 19;
        private const int StartingPositionColNewGame = 35;

        // fields
        private string name;
        private int[] positonOnField;       //position on the field or in the room
        private int health;
        private int healthRange;
        private int mana;
        private int manaRange;
        private List<Item> items;
        private Spell[] spells;
        private char[][] playerEnvironement;
     
        //constructors
        public Player(string name,int mana,int health):this(name)
        {
            this.ManaRange = mana;
            this.HealthRange = health;

        }

        public Player(string name) : this()
        {
            this.Name = name;
            this.positonOnField = new int[2] { StartingPositionRowNewGame, StartingPositionColNewGame };
            
        }

        public Player()
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

        public char[][] PlayerEnvironment => this.playerEnvironement;
       
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

        public void UpdatePlayerEnvironement(char[][] currentSurroundings)
        {
            this.playerEnvironement = currentSurroundings;
        }

    }
}
