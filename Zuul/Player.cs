using System;

namespace Zuul
{
    public class Player
    {
        private int health;
        private Inventory inventory;

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
            // remove the Item from the Room
            // put it in your inventory
            // inspect returned values
            // communicate to the user what's happening
            // return true/false for success/failure

        }
    }
}