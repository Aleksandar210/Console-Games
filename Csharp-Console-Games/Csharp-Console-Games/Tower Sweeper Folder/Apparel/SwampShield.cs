using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class SwampShield:Shield
    {
        //Swamp Shield -> name


        //fields
        //create hit by logic and make the Enemy class abstract
        private Player player;
        private Enemy enemy;
        private bool isPlayerOwner;


        private SwampShield():base("Swamp Shield",60)
        {

        }

        public SwampShield(Enemy enemy):this()
        {

        }

        public SwampShield(Player player):this()
        {

        }


        protected override void EffectOnHit()
        {
            if (this.roarStacks == 5 && this.isPlayerOwner)
            {
                this.player.IncreaseDamage(10 * 5);
                this.roarStacks = 0;
                return;
            }
            else if (this.roarStacks == 5 && !this.isPlayerOwner)
            {
                this.enemy.IncreaseDamage(10 * 5);
                this.roarStacks = 0;
                return;
            }
        }
    }
}
