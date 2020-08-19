using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
   public class IceShield : Shield
    {
        //Ice Shield ->name


        //constructors
        public IceShield():base("Ice Shield",70)
        {

        }

        protected override void EffectOnHit()
        {
            throw new NotImplementedException();
        }
    }
}
