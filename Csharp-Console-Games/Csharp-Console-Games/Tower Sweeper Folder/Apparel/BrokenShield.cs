using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    public class BrokenShield : Shield
    {
        //Broken Shield ->name

        //fields
        private int roarStacks;
        private Player player;
        private Enemy enemy;
        private bool isPlayerOwner;
        

        private BrokenShield():base("Broken Shield",25)
        {

        }

        public BrokenShield(Player player):this()
        {
            this.isPlayerOwner = true;
        }

        public BrokenShield(Enemy enemy):this()
        {
            this.isPlayerOwner = false;
        }


        protected override void EffectOnHit()
        {
            // no effect
        }
    }
}
