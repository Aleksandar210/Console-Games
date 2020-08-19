

using Csharp_Console_Games.Tower_Sweeper_Folder.Apparel;
using Csharp_Console_Games.Tower_Sweeper_Folder.Buildings;
using Csharp_Console_Games.Tower_Sweeper_Folder.Weapons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Csharp_Console_Games.Tower_Sweeper_Folder
{
    class Engine
    {
        //usable resoures
        private StringBuilder sb;
        private HashSet<string> towerCoordiantes;
        private HashSet<string> enemiesCoordiantes;
        private List<string[]> predefinedPlayers;


        //consts
        private const int DefaultNumberTowerSweeped = 0;
        private const int fieldRow = 40;
        private const int fieldCol = 70;

        //fields
        private int numberTowerSweeped;
        private int numberTowersOnTheField;
        private int numberEnemiesOnTheField;
        private Player player;
        private Dictionary<string, Enemy> enemiesOnField;
        private Dictionary<string, Tower> towersOnTheField;
        private Tower currentTowerIn;
        private char[][] field;
        private char[][] currentField;      //may be the main field or just the floor field
        private HashSet<string> enemyNamesStatsCollection;
        private HashSet<string> towerNamesCollection;

        

        //contructors
        public Engine()
        {
            this.enemyNamesStatsCollection = new HashSet<string>();
            this.towerNamesCollection = new HashSet<string>();
            this.towerCoordiantes = new HashSet<string>();
            this.enemiesCoordiantes = new HashSet<string>();
            this.predefinedPlayers = new List<string[]>();
            this.numberTowerSweeped = DefaultNumberTowerSweeped;        //initialise number towers sweeped
            enemiesOnField = new Dictionary<string, Enemy>();           //intialise enemies collection
            towersOnTheField = new Dictionary<string, Tower>();         //initialise towerCoolection
            this.field = new char[fieldRow][];                         //initialise field 2d array
            this.sb = new StringBuilder();                              //initialise stringBuilder
            this.BuildFieldOnStartup();                                 //execute build field func
            
            
        }
        //------------------------------------------------------------------------------------------

        private void AddEnemyNamesFromFile()        //transfer enemy names form the file to the HashSet Collection
        {

            using (var reader = new StreamReader(@"Resources\EnemiesNamesStats.txt"))
            {
                while (reader.Peek() >= 0)
                {
                    reader.ReadLine().Split("|").Select(tName =>
                    {
                        this.enemyNamesStatsCollection.Add(tName);
                        return tName;
                    }
                    );

                }

            }


        }

        private void AddPreDifinedPlayers() //adds pre defined characters from file to collection   //MAY BE REMOVED
        {

        }

        private void AddTowerNames()
        {          
            using (var reader = new StreamReader(@"Resources\TowerNames.txt"))
            {
                while(reader.Peek()>=0)
                {
                    reader.ReadLine().Split(",").Select(tName =>
                    {
                        this.towerNamesCollection.Add(tName);
                        return tName;
                    }
                    );
                    
                }
               
            }

        }

        //PROPERTIES
        //-------------------------------------------------------------------------------------------
        //properties
        private string Field        //updated for real time rendering such as only partial updated
                                    //this will do for now //Same as for room use back buffer programming 
        {
            set
            {
                this.sb.Clear();
                for (int i = 0; i < this.field.GetLength(0); i++)
                {
                    this.sb.Append(new String(this.field[i]) + Environment.NewLine);
                }
            }
            get
            {
                this.Field = "hello world";
                return this.sb.ToString();
            }
        }

        private int NumberEnemiesOnTheField => this.enemiesOnField.Count;

        private int NumberTowersOnTheField => this.towersOnTheField.Count;

        //---------------------------------------------------------------------------------




        //BEHAVIOUR
        //---------------------------------------------------------------------------------
        //behaviour
        private void BuildFieldOnStartup()     //updated for random object placements
        {
            int numberTowersTheFiledHas = RandomTowerNumberGenerator();
            int numberEnemiesTheFieldHas = RandomNumberEnemeyGenerator();

            //adding coordinates of towers on the field     //to do create towers to add in dictioanary as well
            for (int i = 0; i < numberTowersTheFiledHas; i++)
            {
                this.towerCoordiantes.Add(RandomTowerCoordinateGenerator(this.field, this.towerCoordiantes));
                
            }

            for(int i=0;i<numberEnemiesTheFieldHas;i++)
            {
                this.enemiesCoordiantes.Add(this.RandomEnemyCoordinateGenerator(this.enemiesCoordiantes,this.towerCoordiantes));
            }

            for (int i=0;i<this.field.Length;i++)
            {
                this.field[i] = new String('.',70).ToCharArray();
            }

            foreach(var item in this.towerCoordiantes)
            {
                this.BuildTower(this.field, item.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray());
                //this.towersOnTheField.Add(item,);
            }

            int[] tempEnemyCoordiantes;
            string[] tempEnemyStatsArray;
            Shield shiledEnenymWillHave = null;
            Weapon weaponEnemyWillHave = null;
            foreach(var item in this.enemiesCoordiantes)
            {
                tempEnemyCoordiantes = item.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                //fix this with the constructor need to add  shields and so on
                tempEnemyStatsArray = this.SelectRandomEnemyFromCollection();

              this.enemiesOnField.Add(item, new Enemy(tempEnemyStatsArray[0], tempEnemyCoordiantes[0], tempEnemyCoordiantes[1], this.field
                  ,int.Parse(tempEnemyStatsArray[1]),int.Parse(tempEnemyStatsArray[2])),this.AssignEnemyAShield(tempEnemyStatsArray),);
                this.field[tempEnemyCoordiantes[0]][tempEnemyCoordiantes[1]] = this.enemiesOnField[item].VisualiseOnField;
            }

        }

        private string[] SelectRandomEnemyFromCollection()
        {
            Random rand = new Random();
            int enemyIndex = rand.Next(0, this.enemyNamesStatsCollection.Count - 1);
            string enemyStats = this.enemyNamesStatsCollection.ElementAt(enemyIndex);
            this.enemyNamesStatsCollection.Remove(enemyStats);
            return enemyStats.Split(",");
        }

        private Shield AssignEnemyAShield(string[] statsGenerated)
        {
            Shield currentEnemyGeneratedShield = null;
            switch(statsGenerated[3])
            {
                case "Wooden Shield":
                    currentEnemyGeneratedShield = new WoodenShield();
                    break;
                case "Swamp Shield":
                    currentEnemyGeneratedShield = new SwampShield();
                    break;
                case "Rock Shield":
                    currentEnemyGeneratedShield = new RockShield();
                    break;
                case "Ice Shield":
                    currentEnemyGeneratedShield = new IceShield();
                    break;
                case "Lion Shield":
                    currentEnemyGeneratedShield = new LionShield();
                    break;
                case "Dragon Shield":
                    currentEnemyGeneratedShield = new DragonShield();
                    break;
                case "Golden-Lamp-Shield":
                    currentEnemyGeneratedShield = new GoldenLampShield();
                    break;
                case "Emerald Shield":
                    currentEnemyGeneratedShield = new EmeraldShield();
                    break;
                case "Broken Shield":
                    currentEnemyGeneratedShield = new BrokenShield();
                    break;
                case "Hound Shield":
                    currentEnemyGeneratedShield = new HoundShield();
                    break;
                default:
                    break;
                    
            }
            return null;
        }

        private Weapon AssignWeaponToEnemy(string[] statsGenerated)     //finish this
        {
            switch(statsGenerated[4])
            {
                case "Blood Spear":
                    break;
                case "Pirate Sword":
                    break;
                case "Stone Hammer":
                    break;
                case "Blood Mace":
                    break;
                case "Ice Katana":
                    break;
                case "Noble Sword":
                    break;
                    
            }
            return null;
        }
        
        
        /// <summary>
        ///generates coordinates for a tower randomyl and within range
        /// </summary>
        /// <param name="numberEnemies"> it uses field prop indirectly </param>
        /// <returns> array of 2 elements presenting the x and y coordinate </returns>
        private string RandomEnemyCoordinateGenerator(HashSet<string> previousCoordinates
            ,HashSet<string> previousTowerCoordinates)
        {
            int[] coordinates = new int[2];

            do
            {
                coordinates[0] = RandomNumberGenerator(1, field.Length - 1);
                coordinates[1] = RandomNumberGenerator(0, 70 - 1);
            } while (coordinates[0] == coordinates[1] && (!previousCoordinates.Contains(coordinates[0] + " " + coordinates[1])
            && (!previousTowerCoordinates.Contains(coordinates[0]+" "+coordinates[1]) && !this.isEnemySpawnedBetweenTower(coordinates,previousTowerCoordinates))));

            return coordinates[0] + " " + coordinates[1];
        }

        //finish this
        private bool isEnemySpawnedBetweenTower(int[] enemyCoordinates,HashSet<string> towerCoordinates)
        {
            int[] towerPosition=null;
            HashSet<string> getTowersRowsSame = towerCoordiantes.Where(tc =>
            {
                towerPosition = tc.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if((enemyCoordinates[0] >= towerPosition[0] || enemyCoordinates[0]>=towerPosition[0]+5)
                && (enemyCoordinates[1]>=towerPosition[1] && enemyCoordinates[1]<=towerPosition[1]+5))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            ).ToHashSet();
            if(getTowersRowsSame.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
          
            
        }

        /// <summary>
        /// generates random number presenting the enemies needed to be generated on the field
        /// </summary>
        /// <returns> Returns the number of enemies that needs to spawn </returns>
        private int RandomNumberEnemeyGenerator()
        {
            Random rand = new Random();
            return rand.Next(14, 24);
        }

        /// <summary>
        /// Generates how much towers the field should display
        /// </summary>
        /// <returns></returns>
        private int RandomTowerNumberGenerator()
        {
            Random rand = new Random();
            return rand.Next(20, 27);
        }

        /// <summary>
        /// Generates Random Tower Coordinates
        /// </summary>
        /// <param name="field"></param>
        /// <param name="previousCoordinates"></param>
        /// <returns> returns a string of x and y coordinate of tower which si added to the collection hashset</returns>
        private string RandomTowerCoordinateGenerator(char[][]field,HashSet<string> previousCoordinates)
        {
            int[] coordinates = new int[2];

            do
            {
                coordinates[0] = RandomNumberGenerator(7, field.Length - 2);
                coordinates[1] = RandomNumberGenerator(1, 70 - 7);
            } while (coordinates[0] == coordinates[1] && !previousCoordinates.Contains(coordinates[0] + " " + coordinates[1]));

            return coordinates[0] + " " + coordinates[1];
        }

        private int RandomNumberGenerator(int min, int max)
        {
            Random current = new Random();
            return current.Next(min, max) % max;
        }

        private  void BuildTower(char[][] field, params int[] coordinates)
        {
            //sdies and tops bott draw
            int counterSides = coordinates[0];
            int counterTopsBottoms = coordinates[1];
            for (int i = 0; i < 5; i++)
            {
                field[coordinates[0]][counterTopsBottoms] = '_';
                field[coordinates[0] - 4][counterTopsBottoms] = '-';
                counterTopsBottoms++;
            }
            for (int i = 0; i < 5; i++)
            {
                field[coordinates[0]][coordinates[1]] = '|';
                field[coordinates[0]][coordinates[1] + 5] = '|';
                coordinates[0]--;
            }

            field[coordinates[0]][coordinates[1]] = '+';
            
        }

        private void SpawnEnemies(char[][] field,HashSet<string> previousEnemyCoordinates)
        {
            
        }



        /// <summary>
        /// Function that calls the main menue its the first function called in the program
        /// </summary>
        private void MainMenue()
        {
            int select;
            do
            {
                this.sb.Clear();
                Console.Clear();
                sb.Append($"1| New Game." + Environment.NewLine);
                //add load game in future instances and maybe options
                sb.Append($"2| Exit." + Environment.NewLine);
                Console.Write("Select: ");
                select = int.Parse(Console.ReadLine());
            } while (select < 1 || select > 2);
            switch(select)
            {
                case 1:
                    do
                    {
                        this.sb.Clear();
                        this.sb.Append("1| Create Character" + Environment.NewLine);
                        this.sb.Append("2| Chose pre difined character" + Environment.NewLine);
                        this.sb.Append("3| Back" + Environment.NewLine);
                        this.sb.Append("Select: ");
                        select = int.Parse(Console.ReadLine());
                    } while (select < 1 || select > 3);
                   
                    break;
                case 2:

                    break;
            }
             
        }

        public void PlayTowerSepper()
        {
            while(this.numberTowerSweeped!=this.numberTowersOnTheField)
            {
                this.DisplayFieldOnScreen();        //displays field on screen  refreshes afte player or enemy movements
                                                    //waits for player movement

            }
        }

        private void CreateCharacter()
        {
            Regex nameRegex = new Regex(@"[A-Z][a-z]+ [A-Z][a-z]+");
            Match foundValidName;
            do        
            {
                Console.Clear();
                Console.Write("Enter Name: ");
                foundValidName = nameRegex.Match(Console.ReadLine());
                if(!foundValidName.Success)
                {
                    Console.Clear();
                    Console.Write("Enter Name example[Dave Dave]: ");
                    foundValidName = nameRegex.Match(Console.ReadLine());
                }
            }
            while (!foundValidName.Success);
            string name = foundValidName.Value;

            int mana = 0;
            do
            {
                Console.Clear();
                Console.Write("Enter mana: ");
                mana = int.Parse(Console.ReadLine());
                if(mana<1 || mana>800)
                {
                    Console.Clear();
                    Console.Write("Enter mana [1-800]: ");
                    mana = int.Parse(Console.ReadLine());
                }
            }
            while (mana<1 || mana>800);

            int health = 0;
            do
            {
                Console.Clear();
                Console.Write("Enter health: ");
                health = int.Parse(Console.ReadLine());
                if(health<1 || health>800)
                {
                    Console.Clear();
                    Console.Write("Enter health [1-800]: ");
                    health = int.Parse(Console.ReadLine());
                }
            }
            while (health<1 || health>800);
            Console.Clear();
            this.player = new Player(name, mana, health);
        }

        private void ChosePreDifineCharacter()
        {

        }
        
        

        //implement logic  implement past symbol currentSymbol so on
        private void ControlPlayer()
        {
           
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.LeftArrow:
                    this.player.Move("left");
                        return;
                    case ConsoleKey.UpArrow:
                    this.player.Move("forward");
                        break;
                    case ConsoleKey.DownArrow:
                    this.player.Move("backward");
                        break;
                case ConsoleKey.RightArrow:
                    this.player.Move("right");
                    break;

                default:

                    break;
            }
            
        }

        public void DisplayFieldOnScreen()
        {
            Console.Clear();
            Console.WriteLine(this.Field);
        }


        //------------------------------------------------------------------------------------------
        
    }
}
