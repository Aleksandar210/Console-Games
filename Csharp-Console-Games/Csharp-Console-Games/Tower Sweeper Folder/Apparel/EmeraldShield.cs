using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class EmeraldShield : Shield
    {
        //Emerald Shield -> name
        //when hit this shields gets only 5% of the attack value which makes him the rarest shield which reminds me to include rare
        //so to do the logic I have to restore 5 value from the attack to the fixShield method

        //fields
        
        private Player player;
        private Enemy enemy;
        private bool isPlayerOwner;

        private EmeraldShield() : base("Emeral Shield", 150)
        {

        }

        public EmeraldShield(Enemy enemy):this()
        {
            this.isPlayerOwner = false;
            this.enemy = enemy;
        }

        public EmeraldShield(Player player):this()
        {
            this.isPlayerOwner = true;
            this.player = player;
        }

        protected override void EffectOnHit()
        {
            //implement fixBy the rest
        }
    }
}
