using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    

    class Game
    {
        private Player _player;
        private Shop _shop;
        private Item _cinnamonRoll;
        private Item _ramen;
        private Item _appleJuice;
        private Item[] _shopInventory;
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

        private void InitItems()
        {
            _cinnamonRoll.name = "Cinnamon Roll";
            _cinnamonRoll.cost = 10;
            _ramen.name = "Ramen";
            _ramen.cost = 15;
            _appleJuice.name = "Apple Juice";
            _appleJuice.cost = 50;
        }

        public void PrintInventory(Item[] inventory)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + inventory[i].name + inventory[i].cost);
            }
        }

        private void OpenShopMenu()
        {
            //Print a welcome message and all the choices to the screen
            Console.WriteLine("Welcome! Please selct an item.");
            PrintInventory(_shopInventory);

            //Get player input
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

            //If the player can't afford the item print a message to let them know
            if (_player.GetGold() < _shopInventory[itemIndex].cost)
            {
                Console.WriteLine("You cant afford this.");
                return;
            }

            //Ask the player to replace a slot in their own inventory
            Console.WriteLine("Choose a slot to replace.");
            PrintInventory(_player.GetInventory());
            //Get player input
            input = Console.ReadKey().KeyChar;

            //Set the value of the playerIndex based on the player's choice
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

            //Sell item to player and replace the weapon at the index with the newly purchased weapon
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
            InitItems();
            _shopInventory = new Item[] { _cinnamonRoll, _ramen, _appleJuice };
            _shop = new Shop(_shopInventory);
        }

        //Repeated until the game ends
        public void Update()
        {
            OpenShopMenu();
        }

        //Performed once when the game ends
        public void End()
        {

        }
    }
}
