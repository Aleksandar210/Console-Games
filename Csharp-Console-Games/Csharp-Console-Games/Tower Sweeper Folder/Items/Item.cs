using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    public abstract class  Item
    {
        //Resources
        StringBuilder sb;
        private bool isHealingType;
        private bool isDamageType;
        private bool isBuffType;

        //consts
        private const int DefaultDamage = 0;
        private const int DefaultMana = 0;


        //fields
        protected string type;           //either damage or jsut healing type
        protected string name;
        protected int damage;
        protected int healthRestore;
        private int shieldRestore;      //optional
        private int shieldDamage;       //optional
        protected int manaCost;


        //constructors
        protected Item()
        {
            this.Damage = DefaultDamage;
            this.ManaCost = DefaultMana;
            this.isBuffType = false;
            this.isDamageType = false;
            this.isHealingType = false;
        }

        protected Item(string name,string type):this()
        {
            this.sb = new StringBuilder();
            this.Name = name;
        }

        protected Item(string name,string type,params int[] damageHealthShieldBuff):this(name,type)
        {
            switch(damageHealthShieldBuff.Length)
            {
                case 1:

                    break;
            }
        }

        //properties
        protected string Name
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
           private set
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

        protected int Damage
        {
            private set
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

        protected int HealthRestore
        {
            private set
            {

            }

            get { return this.healthRestore; }
        }


        //behaviour
        protected abstract void Effect();


        public override string ToString()
        {
            this.sb.Append($"{this.Name}");
            return sb.ToString();
        }
    }
}
