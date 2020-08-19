using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class BrokenShield : Shield
    {
        //Broken Shield ->name

        public BrokenShield():base("Broken Shield",25)
        {

        }
        protected override void EffectOnHit()
        {
            throw new NotImplementedException();
        }
    }
}
