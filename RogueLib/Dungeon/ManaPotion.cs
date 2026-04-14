using RogueLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RogueLib.Dungeon
{
    public class ManaPotion : Item
    {
        private int _amount;

        public ManaPotion(Vector2 pos, int amount = 10)
      : base(pos, '!', ConsoleColor.Blue)
        {
            _amount = amount;
        }

        public override void Use(Player player)
        {
            player.RestoreMana(_amount);

            Console.SetCursorPosition(0, 23);
            Console.Write($"Restored {_amount} mana!");
        }
    }
}
