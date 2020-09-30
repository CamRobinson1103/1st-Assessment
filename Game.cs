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
    }
    class Game
    {
        private Player _player;
        private Shop _shop;
        private Item _cinnamonRoll;
        private Item _ramen;
        private Item _appleJuice;
        private Item[] _shoppingList;
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
            //Initializing the items
        {
            _cinnamonRoll.name = "Cinnamon Roll";
            _cinnamonRoll.price = 3;
            _ramen.name = "Ramen Packs";
            _ramen.price = 3;
            _appleJuice.name = "Apple Juice";
            _appleJuice.price = 3;
        }

        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + inventory[i].price);
            }
        }

        private void OpenShopMenu()
        {
            //Enters store and items you can purchase
            Console.WriteLine("Welcome to the Grocery Garden!!.");
            PrintInventory(_shoppingList);

            //Player input
            char input = Console.ReadKey().KeyChar;

            //Set itemIndex to be the indec the player selected
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
            if (_player.GetDollars() < _shoppingList[itemIndex].price)
            {
                Console.WriteLine("AYE!! Stop being broke, loser!");
                return;
            }

            //Fills in a slot
            Console.WriteLine("Choose a slot to replace.");
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
            _shoppingList = new Item[] { _cinnamonRoll, _ramen, _appleJuice };
            _shop = new Shop(_shoppingList);
        }

        //Repeated until the game ends
        public void Update()
        {
            OpenShopMenu();
        }

        //Game Over
        public void End()
        {

        }
    }
}
