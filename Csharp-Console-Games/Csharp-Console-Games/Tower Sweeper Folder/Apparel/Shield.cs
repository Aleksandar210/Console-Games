using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    public abstract class Shield
    {

        
        //consts
        private const int DefaultArmour = 1;
        private const string DefaultName = "ShieldName";
        private bool DefaultIsShieldDestroyed = false;
        //fields
        protected string name;
        protected int armourRange;
        protected int currentArmourValue;
        protected bool isShieldDestroyed;
        protected int lastDamageReceived;
        //constructors

        public Shield(string name,int armour)
        {
            this.Name = name;
            this.ArmourRange = armour;
            this.currentArmourValue = this.ArmourRange;
            this.isShieldDestroyed = DefaultIsShieldDestroyed;
        }

        

        //properties
        protected int ArmourRange
        {
            private set
            {
                if(value<=0 || value>150)
                {
                    throw new ArgumentException("Invalid Shield Value");
                }
                else
                {
                    this.armourRange = value;
                }
            }
            get { return this.armourRange; }
        }

        protected string Name
        {
            set
            {
                if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid Name I guess");
                }
                else
                {
                    this.name = value;
                }
            }
            get { return this.name; }
        }

        protected int ArmourValue
        {
            set
            {
                if(value<=0 || value>=this.ArmourRange)
                {
                    throw new ArgumentException("Invalid Armour value ");
                }
            }
            get { return this.currentArmourValue; }
        }


        //behaviour
        public void Hit(int damageReceived)
        {
            this.lastDamageReceived = damageReceived;
            this.EffectOnHit();
            if(this.currentArmourValue-damageReceived<=0)
            {
                this.isShieldDestroyed = true;
                return;
            }
            else
            {
                this.currentArmourValue -= damageReceived;
            }
            
        }

        public void FixShield(int fixBy)
        {
            if(this.ArmourValue+fixBy<=this.ArmourRange)
            {
                this.ArmourValue += fixBy;
            }
            else
            {
                this.ArmourValue = this.ArmourRange;
            }
        }

        protected abstract void EffectOnHit();  //this executes some action from class ShieldEffects

        public override string ToString()
        {
            string shieldData = "Shield: " + this.Name + "|" + $" {this.ArmourValue}/{this.ArmourRange}";
            return shieldData;
        }

    }
}
