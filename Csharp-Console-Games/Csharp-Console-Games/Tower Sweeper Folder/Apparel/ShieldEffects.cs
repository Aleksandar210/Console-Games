using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Apparel
{
    class ShieldEffects     //this class may be deleted
    {
        //Collection with Actins
        private Dictionary<string, Action> currentShieldEffects;

        //you gotta implement class for each shield and add its roperties and fields
        //Actions/effects
        private Action<Shield,Player,Enemy> LionShield = (Shield,player, enemy) =>       //stacks 5 roars and on 5 it deals 10*5 damage to enemy
        {
            if(player is null)
            {
                
            }
            else 
            {

            }
        };

        private Action<Player, Enemy> SnakeShield = (player, enemy) =>      //when hit it deal half damage to the enemy shield
         {
             if (player is null)
             {

             }
             else
             {

             }
         };

        private Action<Player, Enemy> ShieldOfHaskovo = (player, enemy) =>  // increases health if below 50 procent health on hit value
        {
            if (player is null)
            {

            }
            else
            {

            }
        };

        private Action<Player, Enemy> PhoenixOfStaraZagora = (player, enemy) =>     //when doestroyed it generates with half health
        {
            if (player is null)
            {

            }
            else
            {

            }
        };

        private Action<Player, Enemy> BasicWoodenShield = (player, enemy) =>        //does nothing this is finished :)
         {
            
         };

        private Action<Player, Enemy> DualCore2 = (player, enemy) =>        //doubles damage
         {
             if (player is null)
             {

             }
             else
             {

             }
         };

        private Action<Player, Enemy> TronShield = (player, enemy) =>        //throws a disc that goes trough all enemies dealing damage
        {
            if (player is null)
            {

            }
            else
            {

            }
        };

        private Action<Player, Enemy> LustShield = (player, enemy) =>       //takes half of the damage value and it absorbs that much hp form enemy
        {
            if (player is null)
            {

            }
            else
            {

            }
        };

        private Action<Player, Enemy> OneHitShield = (player, enemy) =>     //gets destroyed  on first hit
         {
             if (player is null)
             {

             }
             else
             {

             }
         };

       private Action<Player, Enemy> UndeadShield = (player, enemy) =>     //when destroyed it respawns wiht prev health -10 and so on until its over
       {
           if (player is null)
           {

           }
           else
           {

           }
       };

        private Action<Player, Enemy> AttackDamageShield = (player, enemy) =>       //whe hit it doubles your damage with half the hit
        {
            if (player is null)
            {

            }
            else
            {

            }
        };

       private Action<Player, Enemy> SliperyShield = (player, enemy) =>        //if hit is even number the shielddrops on  the foor
       {
           if (player is null)
           {

           }
           else
           {

           }
       };

        private Action<Player, Enemy> OneProblemShield = (player, enemy) =>     //if damage is beyond 99 the shield doesnt work because being a shield aint one
         {
             if (player is null)
             {

             }
             else
             {

             }

         };

        private Action<Player, Enemy> IKnowShield = (player, enemy) =>   //on hit the shield tells you stuff about the source code
         {
             if (player is null)
             {

             }
             else
             {

             }
         };

        private Action<Player, Enemy> RandomShield = (player, enemy) => //the shield gets logic form every shield randomly on hit
         {
             if (player is null)
             {

             }
             else
             {

             }
         };

        private Action<Player, Enemy> SecondChanceShield = (player,enemy) =>       //when the shield is destroyed it gives you health the ammount is determined by the last attack value by the enemy
         {
             if(player is null)
            {

            }
            else
            {

            }
         };
    }
}
