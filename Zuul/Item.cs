using System;

namespace Zuul
{
    public class Item
    {
        public int Weight { get; }
        public string Name { get; }
        public string Description { get; }

        public Item(int weight, string name, string description)
        {
            Weight = weight;
            Name = name;
            Description = description;
        }
    }
}