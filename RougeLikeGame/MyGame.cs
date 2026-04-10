using RlGameNS;
using RogueLib.Dungeon;
using RogueLib.Engine;
using RogueLib.Utilities;
using SandBox01.Levels;
using Spectre.Console;
using System.Text.Json;
using System.Xml.Linq;

namespace SandBox01;


public class MyGame : Game
{

    private void init()
    {
        // To create a new game just need to 
        // 'inject' an IRenderWindow to draw the game one
        // 'inject' a Player, the player lives outside or the Scene's because the 
        // player visits all the scenes and takes their inventory with them. 
        // you must load the first leveel, and your level or your game must manage 
        // the level switching. 

        _window = new ScreenBuff();
        _player = new Rogue();
        _currentLevel = new Level(_player!, map1, this);

    }

    public MyGame()
    {
        // init level on construction 
        init();
    }
    public void ShowInventory()
    {
        try { Console.SetCursorPosition(0, 0); } catch { }
        Console.Clear();
        AnsiConsole.MarkupLine("[yellow]Inventory:[/]");
        // Show currency (gold) separately since Gold is treated as currency, not an inventory Item
        AnsiConsole.MarkupLine($"[green]Gold:[/] {_player.Gold}");

        if (_player.Items.Count != 0)
        {
            foreach (var item in _player.Items)
            {
                AnsiConsole.MarkupLine($"- {item.Name}: {item.Description}");
            }
        }
        else
        {
            AnsiConsole.MarkupLine("[grey]Your inventory is empty.[/]");
        }

        AnsiConsole.MarkupLine("[grey]Press any key to go back.[/]");
        Console.ReadKey(true);
        try { Console.SetCursorPosition(0, 0); } catch { }
        Console.Clear();
    }
    private record GameDTO
    {
        public string PlayerName { get; init; }
        public int PlayerGold { get; init; }
        public string Map { get; init; }
        public Item.ItemDTO[]? Inventory { get; init; }
    }


    // ----------------------------------------------------------------
    // string to use as the backgound on our first level
    // ----------------------------------------------------------------

    public const string map1 =
       """

               ┌──────┐          ┌─────────────┐
               │......│        ##+.............│            ┌───────┐
               │......│        # │.............+##          │.......│
               │......+######### └──────────+──┘ ###########+.......│
               │......│                     #               └───────┘
               └──+───┘                     #
           ########                 #########
      ┌────+┐                     ┌─+───────┐              ┌──────────────────┐
      │.....│                     │.........│              │..................│
      │.....+#####################+.........│              │..................│
      │.....│                     │.........│              │..................│
      │.....│                     │.........│              │..................│
      │.....│                     │.........+##############+..................│
      └─+───┘                     └───+─────┘              └───────────────+──┘
        #                             #                                    #
        ######               ┌────────+──────────────┐                     #
             #             ##+.......................|                     #
             #             # |.......................|   ###################
             #             # |.......................|   #
             #             # |.......................+####
             #             # └───────────────────────┘
             ###############
             
             
      """;



}
