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
        private Item _hands;
        private string _name;
        private float _health;
        protected float _damage;

        public Player()
        {
            _dollars = 10;
            //Creates a new item array with three items with default values
            _inventory = new Item[3];
        }

        public Player(string nameVal, float healthVal, float damageVal, int inventorySize)
            
        {
            _inventory = new Item[inventorySize];
            _hands.name = "These hands";
            _hands.statBoost = 0;
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
            return true;
        }

    }
}


