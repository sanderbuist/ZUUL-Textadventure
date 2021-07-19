using System;

namespace Zuul
{
    public class Player
    {
        private int health;
        public Inventory inventory;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Room CurrentRoom { get; set; }
        public Player()
        {
            CurrentRoom = null;
            health = 100;
            inventory = new Inventory(25);
        }

        public bool TakeFromChest(string itemName)
        {
            // communicate to the user what's happening
            // return true/false for success/failure
            //if item "item" in room = remove item from room;
            //put removed item into player inventory;
            //inspect values of item taken from chest;
            //tell user that everything went good(put in console);
            //return true / false;
            Item item = CurrentRoom.Chest.Get(itemName);
            if (item == null)
            {
                return false;
            }
            else
            {
                inventory.Put(item);
                return true;
            }
            
        }

        public bool DropToChest(string itemName)
        {
            // remove Item from your inventory.
            // Add the Item to the Room
            // inspect returned values
            // communicate to the user what's happening
            // return true/false for success/failure
            Item item = inventory.Get(itemName);
            if (item == null)
            {
                return false;
                //Console.Writeline("het werkt niet :(");
            }
            else
            {
                inventory.Put(item);
                return true;
                //Console.WriteLine("Het werkt :)");
            }
        }
    }
}