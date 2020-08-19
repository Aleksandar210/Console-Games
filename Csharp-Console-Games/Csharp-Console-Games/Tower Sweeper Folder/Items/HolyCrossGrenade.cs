using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Items
{
    public class HolyCrossGrenade : Item
    {
        //consts
        private const string DefautName = "HolyCrossGrenade";

        //fields
        private string name;
        
       

        //constructors
        public HolyCrossGrenade()
        {
            this.name = DefautName;
            //this.isD
        }

        protected override int CriticalDamageIncrease()
        {
            throw new NotImplementedException();
        }




        //implement effect here
        protected override void Effect()
        {
            throw new NotImplementedException();
        }
    }
}
