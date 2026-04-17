using System;
using System.Collections.Generic;
using System.Text;
using RogueLib;
using RogueLib.Engine;
using SandBox01;

namespace SandBox01.Levels
{
    public class Rules : Game
    {
        List<string> rules = new List<string>()
        {
            "Rule one: The player can move up, down, left, right with the arrow keys.",
            "\nRule two: To pass the level you must defeat the boss",
            "\nRule three: You can pick up items to help you defeat the boss",
            "\nRule four: You can use items to heal yourself or damage the boss",
            "\nRule five: You can enter inventory with 'i' and navigate it with up/down arrows",
            "\nRule six: You can use items in inventory with 'enter' key",
            "\nRule seven: You can exit inventory with 'esc' key",
            "\nRule eight: You can leave and save with 'q'"

        };
        public string GetRules()
        {
            return string.Join("\n", rules);
        }
    }
}
