using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class WoodenShield : Shield
    {
        //Wooden Shield -> name

        public WoodenShield():base("Wooden Shield",50)
        {

        }
        protected override void EffectOnHit()
        {
            throw new NotImplementedException();
        }
    }
}
