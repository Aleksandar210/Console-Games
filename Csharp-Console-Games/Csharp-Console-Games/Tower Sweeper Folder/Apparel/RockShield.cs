using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class RockShield:Shield
    {

        public RockShield():base("Rock Shield",120)
        {

        }

        protected override void EffectOnHit()
        {
            throw new NotImplementedException();
        }
        //Rock Shield ->name
    }
}
