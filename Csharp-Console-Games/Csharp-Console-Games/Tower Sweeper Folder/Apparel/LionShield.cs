using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class LionShield : Shield
    {
        //consts
        private const string LionShieldName = "LionShield";
        private const int LionShieldArmourValue = 100;
        private const int RoarStacksDefault = 0;
        
        //fields
        private int roarStacks;
        private Player player;
        private Enemy enemy;
        private bool isPlayerOwner;
    

        //construcotrs
        private LionShield():base(LionShieldName, LionShieldArmourValue)
        {
            this.roarStacks = RoarStacksDefault;
            
        }

        public LionShield(Player player):this()
        {
            this.isPlayerOwner = true;
        }

        public LionShield(Enemy enemy):this()
        {
            this.isPlayerOwner = false;
        }

        //properties


        //behaviour
  
        protected override void EffectOnHit()
        {
            if(this.roarStacks==5 && this.isPlayerOwner)
            {
                this.player.IncreaseDamage(10 * 5);
                this.roarStacks = 0;
                return;
            }
            else if(this.roarStacks==5 && !this.isPlayerOwner)
            {
                this.enemy.IncreaseDamage(10 * 5);
                this.roarStacks = 0;
                return;
            }

            this.roarStacks++;
        }
    }
}
