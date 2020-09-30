using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HelloWorld
{
    class Player
    {
        private int _dollars;
        private Item[] _inventory;
        private string _name;

        public Player()
        {
            _dollars = 10;
            //Creates a new item array with three items with default values
            _inventory = new Item[3];
        }

        public bool Buy(Item item, int inventoryIndex)
        {
            //Check to see if the player can afford the item
            if (_dollars >= item.price)
            {
                //Pay for item.
                _dollars -= item.price;
                //Place item in inventory array.
                _inventory[inventoryIndex] = item;
                return true;
            }

            return false;
        }

        public int GetDollars()
        {
            return _dollars;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        public virtual void Save(StreamWriter writer)
        {
            //Save the characters stats
            writer.WriteLine(_name);
        }

        public virtual bool Load(StreamReader reader)
        {
            //Create variables to store loaded data.
            string name = reader.ReadLine();
            float damage = 0;
            float health = 0;
            //Checks to see if loading was successful.
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out damage) == false)
            {
                return false;
            }
            //If successful, set update the member variables and return true.
            _name = name;
            return true;
        }

    }
}


