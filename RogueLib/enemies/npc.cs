using RogueLib.Dungeon;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RogueLib.enemies
{
    public class NPC 
    {
         Goblin goblin;
         Merchent Trader;
          Boss Rapheal;
         public NPC(Vector2 pos)
        {
            goblin = new Goblin(pos, "Goblin", 10);
            Trader = new Merchent(pos, "Merchent", 7);
            Rapheal = new Boss(pos, "Rapheal", 20);
        }
    }
}
