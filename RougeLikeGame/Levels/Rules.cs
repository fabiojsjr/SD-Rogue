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
            "rule one: the player can move up, down, left, right with the arrow keys.",
            "\nrule two: to pass the level you must defeat the boss"
        };
        public string GetRules()
        {
            return string.Join("\n", rules);
        }
    }
}
