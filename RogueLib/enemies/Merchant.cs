using RogueLib.Utilities;
using Spectre.Console;
using RogueLib.Dungeon;

namespace RogueLib.enemies
{
    public class Merchant : NPC
    {
        public Merchant(Vector2 pos) : base(pos, "Merchant", 'M', ConsoleColor.Yellow, 20, 0) { }


        public override void Update()
        {
            // Merchants do not attack or move
            if (PlayerRef != null && (Pos - PlayerRef.Pos).Length == 1)
            {
            }
        }
        private int _shopIndex = 0;
        public void TalkToMerchant()
        {
            int start = 5;
            ConsoleKey key;

            var shopItems = new (string Name, int Price, Func<Item> Create)[]
            {
                ("Health Potion", 10, () => new Potion(PlayerRef.Pos)),
                ("Strength Potion", 20, () => new StrengthPotion(PlayerRef.Pos)),
                ("Mana Potion", 15, () => new ManaPotion(PlayerRef.Pos, 20)),
            };

            do
            {
                DrawShopWindow(start, shopItems);

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow && _shopIndex > 0)
                    _shopIndex--;

                if (key == ConsoleKey.DownArrow && _shopIndex < shopItems.Length - 1)
                    _shopIndex++;
                if (key == ConsoleKey.Enter)
                {
                    var item = shopItems[_shopIndex];

                    if (PlayerRef.Gold >= item.Price)
                    {
                        PlayerRef.Gold -= item.Price;
                        PlayerRef.Add(item.Create());

                        Console.SetCursorPosition(0, start + 16);
                        Console.WriteLine($"You bought: {item.Name} for {item.Price} gold!");
                    }
                    else
                    {
                        Console.SetCursorPosition(0, start + 16);
                        Console.WriteLine($"Not enough gold for {item.Name}!");
                    }

                    Console.ReadKey(true);
                }

            } while (key != ConsoleKey.Escape);

            FadeOutShop(start);
        }
        private void DrawShopWindow(int start,
    (string Name, int Price, Func<Item> Create)[] items)
        {
            // Clear panel area
            for (int row = start; row <= start + 14; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            // Top border
            Console.SetCursorPosition(0, start);
            Console.WriteLine("┌──────────────────────────────────────────┐");

            // Title
            Console.SetCursorPosition(0, start + 1);
            Console.WriteLine("│               === SHOP ===               │");

            // Spacer
            Console.SetCursorPosition(0, start + 2);
            Console.WriteLine("│                                          │");

            int line = start + 3;

            for (int i = 0; i < items.Length; i++)
            {
                bool selected = (i == _shopIndex);
                var item = items[i];

                Console.SetCursorPosition(0, line);

                string arrow = selected ? ">" : " ";

                if (selected)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write($"│ {arrow} {item.Name,-20} {item.Price,5} gold        │");

                Console.ResetColor();

                line++;
            }

            // Fill remaining rows
            while (line < start + 14)
            {
                Console.SetCursorPosition(0, line);
                Console.WriteLine("│                                          │");
                line++;
            }

            // Bottom border
            Console.SetCursorPosition(0, start + 14);
            Console.WriteLine("└──────────────────────────────────────────┘");

            // Instructions
            Console.SetCursorPosition(0, start + 16);
            Console.WriteLine("Use ↑ ↓ to navigate, Enter to buy, Esc to exit.");
        }
        private void FadeOutShop(int start)
        {
            for (int opacity = 0; opacity < 3; opacity++)
            {
                for (int row = start; row <= start + 14; row++)
                {
                    Console.SetCursorPosition(0, row);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
                Thread.Sleep(30);
            }
        }

        //private void TalkToMerchant()
        //{
        //    var panel = new Panel(
        //        "[yellow]Merchant[/]\n" +
        //        "Welcome traveler! Choose your item."
        //    )
        //    {
        //        Border = BoxBorder.Double,
        //        Padding = new Padding(1, 1),
        //        Expand = false
        //    };
        //    AnsiConsole.Write(panel);

        //    var choice = AnsiConsole.Prompt(
        //        new SelectionPrompt<string>()
        //            .Title("Hello there! I am this dungeons' resident [yellow]Merchant[/]! Please, browse my wares!")
        //            .AddChoices(new[] {
        //                "Buy Health Potion (10 gold)",
        //                "Buy Strength Potion (20 gold)",
        //                "Buy Mana Potion (15 gold)",
        //                "Exit"
        //            }));

        //    switch (choice)
        //    {
        //        case "Buy Health Potion (10 gold)":
        //            if (PlayerRef.Gold >= 10)
        //            {
        //                PlayerRef.Gold -= 10;
        //                PlayerRef.Add(new Potion(PlayerRef.Pos));
        //                AnsiConsole.MarkupLine("[green]You bought a Health Potion![/]");
        //            }
        //            else
        //            {
        //                AnsiConsole.MarkupLine("[red]You don't have enough gold![/]");
        //            }
        //            break;
        //        case "Buy Strength Potion (20 gold)":
        //            if (PlayerRef.Gold >= 20)
        //            {
        //                PlayerRef.Gold -= 20;
        //                PlayerRef.Add(new StrengthPotion(PlayerRef.Pos));
        //                AnsiConsole.MarkupLine("[green]You bought a Strength Potion![/]");
        //            }
        //            else
        //            {
        //                AnsiConsole.MarkupLine("[red]You don't have enough gold![/]");
        //            }
        //            break;
        //        case "Buy Mana Potion (15 gold)":
        //            if (PlayerRef.Gold >= 15)
        //            {
        //                PlayerRef.Gold -= 15;
        //                PlayerRef.Add(new ManaPotion(PlayerRef.Pos));
        //                AnsiConsole.MarkupLine("[green]You bought a Mana Potion![/]");
        //            }
        //            else
        //            {
        //                AnsiConsole.MarkupLine("[red]You don't have enough gold![/]");
        //            }
        //            break;
        //        case "Exit":
        //            AnsiConsole.MarkupLine("[yellow]Thank you for visiting my shop![/]");
        //            break;
        //    }
        //}
    }
}