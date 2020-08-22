using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public abstract class  Item
    {
        //Resources
        StringBuilder sb;   //?? I dont remember why I put this here
        protected bool isHealingType;
        protected bool isDamageType;
        protected bool isBuffType;

        //consts
        private const int DefaultDamage = 1;
        private const int DefaultMana = 1;
        private const int DefaultHealthRestore = 1;


        //fields
        protected string type;           //either damage or jsut healing type
        protected string name;
        protected int damage;
        protected int healthRestore;
        protected int healthBuff;         //not implemented yet.
        protected int shieldRestore;      //optional
        protected int shieldDamage;       //optional
        protected int manaCost;           //depleates from mana on use-method


        //constructors
        protected Item()
        {
            this.Damage = DefaultDamage;
            this.ManaCost = DefaultMana;
            this.isBuffType = false;
            this.isDamageType = false;
            this.isHealingType = false;
            this.shieldDamage = 0;
            this.shieldRestore = 0;
            this.HealthRestore = DefaultHealthRestore;
            this.sb = new StringBuilder();  //?? no clue why I put this
        }

        protected Item(string name,params string[] type):this()
        {
            this.Name = name;
           
        }

        protected Item(string name,string[] type,params int[] damageHealthShieldBuff):this(name,type)   //finish this
        {
            switch(damageHealthShieldBuff.Length)
            {
                case 1:

                    break;
            }
        }

        //properties

        public string Name
        {
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                else
                {
                    this.name = value;
                }
            }
            get { return this.name; }
        }

        protected int ManaCost
        {
            set
           {
                if(value<0 || value>700)
                {
                    throw new ArgumentException("Invalid mana cost range [0-700]");
                }
                else
                {
                    this.manaCost = value;
                }
           }
            get { return this.manaCost; }
        }

        protected  int Damage
        {
            set
            {
                if(value<=0 || value>=800)
                {
                    throw new ArgumentException("Invalid damage range [1-799]");
                }
                else
                {
                    this.damage = value;
                }
            }
            get { return this.damage; }
        }

        protected int HealthRestore        //there has to be a better way ?
        {
             set
            {
                if(value<0)
                {
                    throw new ArgumentException("Invalid Health Restore.");
                }
                else
                {
                    this.healthRestore = value;
                }
            }

            get { return this.healthRestore; }
        }

        protected int ShiledRestore
        {
              set
             {
                if(value<=0)
                {
                    throw new ArgumentException("Invalid Shield Buff value");
                }
                else
                {
                    this.shieldRestore = value;
                }
            }
            get { return this.shieldRestore; }
        }

        protected int ShieldDamageDeal
        {
             set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Invalid shieldDamage value");
                }
                else
                {
                    this.shieldDamage = value;
                }
            }
            get { return this.shieldDamage; }
        }


        //behaviour
        //items have their own damage as well it depends on the item

        public abstract void Effect();   
        protected abstract int CriticalDamageIncrease();    //depends on item

        protected abstract void IncreaseHealthRange();       //depends on item

        protected abstract void HealUser();     //depends on item

        protected abstract void RestoreShieldArmour();  //depends on item

        protected abstract void IncreaseDamage();       //depedns on item

        private void DeterminType(string[] types) // by including types we can sort them in the shop.
        {
            foreach(var item in types)
            {
                switch(item.ToLower())
                {
                    case "healing":
                        this.isHealingType = true;
                        break;
                    case "buff":
                        this.isBuffType = true;
                        break;
                    case "damage":
                        this.isDamageType = true;
                        break;
                }
            }
        }
        
       
        public override string ToString()
        {
            return this.Name;
        }
    }
}
