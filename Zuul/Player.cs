using System;

namespace Zuul
{
    public class Player
    {
        private int health;
        public Room CurrentRoom { get; set; }
        public Player()
        {
            CurrentRoom = null;
            health = 100;
        }
    }
}