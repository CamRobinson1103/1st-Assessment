using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    struct Item
    {
        public string name;
        public int price;
        public int statBoost;
    }
    class Game
    {
        private Player _player;
        private Shop _shop;
        private Item _cinnamonRoll;
        private Item _ramen;
        private Item _appleJuice;
        private Item[] _groceryList;
        private bool _gameOver;
        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();
        }

        private void InitializeItems() 
            //Initializing items
        {
            _cinnamonRoll.name = "Cinnamon Roll";
            _cinnamonRoll.price = 3;
            _ramen.name = "Ramen Packs";
            _ramen.price = 3;
            _appleJuice.name = "Apple Juice";
            _appleJuice.price = 3;
        }

         public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            //Print description to console
            Console.WriteLine(query);
            //print options to console
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write("> ");

            input = ' ';
            //loop until valid input is received
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }


        public Player CreateCharacter()
        {
            Console.WriteLine("Wait.... What's my name again?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            return player;
            
        }

        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + inventory[i].price);
            }
        }

        private void GroceryGarden()
        {
            //Enters store and items you can purchase
            Console.WriteLine("Welcome to the Grocery Garden!!.");
            PrintInventory(_groceryList);

            //Player input
            char input = Console.ReadKey().KeyChar;

            //Set itemIndex to be the index the player selected
            int itemIndex = -1;
            switch (input)
            {
                case '1':
                    {
                        itemIndex = 0;
                        break;
                    }
                case '2':
                    {
                        itemIndex = 1;
                        break;
                    }
                case '3':
                    {
                        itemIndex = 2;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            //Player cannot afford item
            if (_player.GetDollars() < _groceryList[itemIndex].price)
            {
                Console.WriteLine("AYE!! Stop being broke!");
                return;
            }

            //Fills in a slot
            Console.WriteLine("Where do you want it at?");
            PrintInventory(_player.GetInventory());
            //Get player input
            input = Console.ReadKey().KeyChar;

            //Value of Playerindex based on choice
            int playerIndex = -1;
            switch (input)
            {
                case '1':
                    {
                        playerIndex = 0;
                        break;
                    }
                case '2':
                    {
                        playerIndex = 1;
                        break;
                    }
                case '3':
                    {
                        playerIndex = 2;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

            //Sell item ffor new item
            _shop.Sell(_player, itemIndex, playerIndex);
        }





        public void Save()
        {
            //Create a new stream writer.
            StreamWriter writer = new StreamWriter("SaveData.txt");
            //Call save for both instances for player.
            _player.Save(writer);
            //Close writer.
            writer.Close();
        }

        public void Load()
        {
            //Create a new stream reader.
            StreamReader reader = new StreamReader("SaveData.txt");
            //Call load for each instance of player to load data.
            _player.Load(reader);
            //Close reader
            reader.Close();
        }
            

        //Performed once when the game begins
        public void Start()
        {
            _gameOver = false;
            _player = new Player();
            InitializeItems();
            _groceryList = new Item[] { _cinnamonRoll, _ramen, _appleJuice };
            _shop = new Shop(_groceryList);
        }

        //Repeated until the game ends
        public void Update()
        {
            CreateCharacter();
            GroceryGarden();
        }

        //Game Over
        public void End()
        {

        }
    }
}
