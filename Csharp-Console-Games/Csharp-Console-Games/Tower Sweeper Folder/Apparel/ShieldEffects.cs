using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class ShieldEffects
    {
        //Collection with Actins
        private Dictionary<string, Action> currentShieldEffects;

        //Actions/effects
        private Action LionShield = () =>       //stacks 5 roars and on 5 it deals 10*5 damage to enemy
        {

        };

        private Action SnakeShield = () =>      //when hit it deal half damage to the enemy shield
         {

         };

        private Action ShieldOfHaskovo = () =>  // increases health if below 50 procent health on hit value
        {

        };

        private Action PhoenixOfStaraZagora = () =>     //when doestroyed it generates with half health
        {

        };

        private Action BasicWoodenShield = () =>        //does nothing this is finished :)
         {

         };

        private Action DualCore2 = () =>        //doubles damage
         {

         };

        private Action TronShield = () =>        //throws a disc that goes trough all enemies dealing damage
        {

        };

        private Action LustShield = () =>       //takes half of the damage value and it absorbs that much hp form enemy
        {

        };

        private Action OneHitShield = () =>     //gets destroyed  on first hit
         {

         };

       private Action UndeadShield = () =>     //when destroyed it respawns wiht prev health -10 and so on until its over
       {

       };

        private Action AttackDamageShield = () =>       //whe hit it doubles your damage with half the hit
        {

        };
    }
}
