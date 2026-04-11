using RogueLib.Dungeon;
using RogueLib.Engine;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace RogueLib.enemies
{
    public class Goblin : Item
    {
        private Vector2 vector2;

        public string Name { get; set; }
        public int Health { get; set; } = 50;
        public Goblin(Vector2 pos, string name, int health) : base('☠', pos, ConsoleColor.DarkGreen)
        {
                 Name = name;
                 Health = health;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
