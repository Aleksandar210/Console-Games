using System;
using System.Collections.Generic;
using System.Text;

namespace Csharp_Console_Games.Tower_Sweeper_Folder.Buildings
{
   public class Floor
    {
        //resources
        private StringBuilder sb;
        private HashSet<string> enemyCoordinatesOnFloor;
        private HashSet<string> chestCoordinatesOnFloor;

        //field
        private int floorCount;
        private Dictionary<string, Enemy> currentEnemeisOnFloor;
        //private Dictionary<string, Chest> currentChestsOnFloor;

        
    }
}
