using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class SwampShield:Shield
    {
        //constatns
        private const int DefaultRootStackValue = 0;


        //fields
        private int rootStacks;
        private Player player;
        private Enemy enemy;
        private bool isPlayerOwner;


        private SwampShield():base("Swamp Shield",60)
        {
            this.rootStacks = DefaultRootStackValue;
        }

        public SwampShield(Enemy enemy):this()
        {
            this.isPlayerOwner = false;
            this.enemy = enemy;
        }

        public SwampShield(Player player):this()
        {
            this.isPlayerOwner = true;
            this.player = player;
        }


        //on every 3 stacks the shield fixes 5 % of its armour
        protected override void EffectOnHit()
        {
            this.rootStacks++;
            if (this.rootStacks%3==0 && this.isPlayerOwner)
            {
                
                return;
            }
            else if (this.rootStacks%3==0 && !this.isPlayerOwner)
            {
                
            }
        }
    }
}
