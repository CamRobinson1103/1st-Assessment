using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop : Item
    {
        private int _dollars;
        private Item[] _inventory;

        public Shop()
        {
            _dollars = 100;
            _inventory = new Item[3];
        }

        public Shop(Item[] items)
        {
            _dollars = 100;
            //Set our inventory array to be the array of items that was passed in.
            _inventory = items;
        }

        public bool Sell(Player player, int itemIndex, int playerIndex)
        {
            //Find the item to buy in the inventory array
            Item itemToBuy = _inventory[itemIndex];
            //Check to see if the player ourchased the item successfully.
            if (player.Buy(itemToBuy, playerIndex))
            {
                //Increase shops gold by item cost to complete the transaction
                _dollars += itemToBuy.cost;
                return true;
            }
            return false;
        }
    }
}

