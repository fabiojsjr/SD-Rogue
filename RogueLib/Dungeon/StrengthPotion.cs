using RogueLib.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RogueLib.Dungeon
{
    public class StrengthPotion : Item
    {
        public StrengthPotion(Vector2 pos)
       : base(pos, '!', ConsoleColor.Magenta) { }

        public override void Use(Player player)
        {
            player.ApplyStrengthBuff(5, 10);
        }
    }
}
