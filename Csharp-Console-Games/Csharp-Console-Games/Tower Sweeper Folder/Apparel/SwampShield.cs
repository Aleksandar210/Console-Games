using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class SwampShield:Shield
    {
        //Swamp Shield -> name

        public SwampShield():base("Swamp Shield",60)
        {

        }

        protected override void EffectOnHit()
        {
            throw new NotImplementedException();
        }
    }
}
