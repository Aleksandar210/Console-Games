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
        private Action<Player,Enemy> LionShield = () =>       //stacks 5 roars and on 5 it deals 10*5 damage to enemy
        {

        };

        private Action<Player, Enemy> SnakeShield = () =>      //when hit it deal half damage to the enemy shield
         {

         };

        private Action<Player, Enemy> ShieldOfHaskovo = () =>  // increases health if below 50 procent health on hit value
        {

        };

        private Action<Player, Enemy> PhoenixOfStaraZagora = () =>     //when doestroyed it generates with half health
        {

        };

        private Action<Player, Enemy> BasicWoodenShield = () =>        //does nothing this is finished :)
         {

         };

        private Action<Player, Enemy> DualCore2 = () =>        //doubles damage
         {

         };

        private Action<Player, Enemy> TronShield = () =>        //throws a disc that goes trough all enemies dealing damage
        {

        };

        private Action<Player, Enemy> LustShield = () =>       //takes half of the damage value and it absorbs that much hp form enemy
        {

        };

        private Action<Player, Enemy> OneHitShield = () =>     //gets destroyed  on first hit
         {

         };

       private Action<Player, Enemy> UndeadShield = () =>     //when destroyed it respawns wiht prev health -10 and so on until its over
       {

       };

        private Action<Player, Enemy> AttackDamageShield = () =>       //whe hit it doubles your damage with half the hit
        {

        };

       private Action<Player, Enemy> SliperyShield = (player, enemy) =>        //if hit is even number the shielddrops on  the foor
       {

       };

        private Action<Player, Enemy> OneProblemShield = (player, enemy) =>     //if damage is beyond 99 the shield doesnt work because being a shield aint one
         {


         };

        private Action<Player, Enemy> IKnowShield = (player, enemy) =>   //on hit the shield tells you stuff about the source code
         {

         };

        private Action<Player, Enemy> RandomShield = (player, enemy) => //the shield gets logic form every shield randomly on hit
         {

         };

        private Action<Player, Enemy> SecondChanceShield = (player,enemy) =>       //when the shield is destroyed it gives you health the ammount is determined by the last attack value by the enemy
         {

         };
    }
}
