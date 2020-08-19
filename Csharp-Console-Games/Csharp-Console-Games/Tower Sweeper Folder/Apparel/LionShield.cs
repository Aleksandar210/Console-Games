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
        public LionShield():base(LionShieldName, LionShieldArmourValue)
        {
            this.roarStacks = RoarStacksDefault;
        }

        //properties


        //behaviour

        private void AssignOwner(Player player,Enemy enemy)
        {
            if(player is null)
            {
                this.enemy = enemy;
                this.isPlayerOwner = false;
            }
            else
            {
                this.player = player;
                this.isPlayerOwner = true;
            }
        }
        protected override void EffectOnHit()
        {
            if(this.roarStacks==5 && this.isPlayerOwner)
            {
                //this.player.In
            }
            this.roarStacks++;
        }
    }
}
