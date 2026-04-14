using RogueLib.Dungeon;
using RogueLib.Engine;
using RogueLib.Utilities;
using System;

namespace RougeLikeGame.Levels
{
    public class Potion : Item
    {
        public string PotionName { get; set; }

        public Potion(Vector2 pos, string name, char glyph, ConsoleColor color)
    : base(pos, glyph, color)
        {
            PotionName = name;
        }

        public override string Name => PotionName;

        public override string Description => "Restores health.";
        public override void Use(Player player)
        {
            int healAmount = 10;

            player.Heal(healAmount); // you need this method (next step)

            Console.SetCursorPosition(0, 23);
            Console.Write($"You used a {Name} and healed {healAmount} HP!");
        }
    }
}
