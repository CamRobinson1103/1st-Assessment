using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop 
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
            _dollars = 10;
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
                //Increase shops dollaers by item cost to complete the pruchase
                _dollars += itemToBuy.price;
                return true;
            }
            return false;
        }
    }
}

