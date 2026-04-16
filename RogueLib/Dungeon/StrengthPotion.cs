using RogueLib.Utilities;
using System;

namespace RogueLib.Dungeon
{
    public class StrengthPotion : Item
    {
        public StrengthPotion(Vector2 pos)
            : base(pos, "💪", ConsoleColor.Magenta)
        {
        }

        public override string Description => "Strength buff";

        public override void Use(Player player)
        {
            player.ApplyStrengthBuff(5, 10);
        }
    }
}
