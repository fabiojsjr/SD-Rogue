using Microsoft.VisualBasic;
using RogueLib.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace RogueLib.Dungeon
{
    public class Inventory
    {
        private readonly List<Item> _items = new List<Item>();
        public void Add(Item item) {
            if (item == null) return;
            _items.Add(item);
        }
        public bool Remove(Item item) => _items.Remove(item);
        public IReadOnlyList<Item> Items => _items.AsReadOnly();
    }
}
