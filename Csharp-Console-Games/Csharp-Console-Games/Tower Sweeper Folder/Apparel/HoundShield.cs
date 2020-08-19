using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class HoundShield:Shield
    {
        //Hound Shield ->name
        public HoundShield():base("Hound Shield",100)
        {

        }

        protected override void EffectOnHit()
        {
            throw new NotImplementedException();
        }
    }
}
