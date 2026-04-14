using System;
using RogueLib.Dungeon;
using RogueLib.Utilities;
using RougeLikeGame.Levels;


namespace RougeLikeGame.Levels
{
    public class Gold(Vector2 pos, int amount) : Item(pos, '*', ConsoleColor.Yellow)
    {
        private readonly int _amount = amount;
    

        public int Amount => _amount;
        public override string Name => "Gold";
        public override string Description => $"A pile of {Amount} gold coins.";

        public override ItemDTO ToDTO() => new ItemDTO { Type = "Gold", Amount = _amount };
    }
}