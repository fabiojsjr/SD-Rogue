using RogueLib.Utilities;
using System;

namespace RogueLib.Dungeon
{
    public class XP : Item
    {
        private readonly int _amount;

        public XP(Vector2 pos, int amount) : base(pos, '₤', ConsoleColor.Green)
        {
            _amount = amount;
        }

        public int Amount => _amount;
        public override string Name => "XP";
        public override string Description => $" {Amount} experience points given.";

        public override ItemDTO ToDTO() => new ItemDTO { Type = "XP", Amount = _amount };
    }
}
