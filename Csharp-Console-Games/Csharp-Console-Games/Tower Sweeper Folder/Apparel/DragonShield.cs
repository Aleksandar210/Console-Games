using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class DragonShield : Shield
    {
        //Dragon Shield -> name

        public DragonShield():base("Dragon Shield",150)
        {

        }
        protected override void EffectOnHit()
        {
            throw new NotImplementedException();
        }
    }
}
