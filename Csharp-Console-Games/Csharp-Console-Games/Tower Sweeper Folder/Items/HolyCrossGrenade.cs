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
        public HolyCrossGrenade():base()
        {
            this.name = DefautName;
            //this.isD
        }

        protected override int CriticalDamageIncrease()
        {
            throw new NotImplementedException();
        }




        //implement effect here
        public override void Effect()
        {
            throw new NotImplementedException();
        }

        protected override void IncreaseHealthRange()
        {
            throw new NotImplementedException();
        }

        protected override void HealUser()
        {
            throw new NotImplementedException();
        }

        protected override void RestoreShieldArmour()
        {
            throw new NotImplementedException();
        }

        protected override void IncreaseDamage()
        {
            throw new NotImplementedException();
        }
    }
}
