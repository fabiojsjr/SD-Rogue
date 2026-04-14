
using RogueLib.Dungeon;
using RogueLib.Engine;
using System.Text.RegularExpressions;

namespace RogueLib.Utilities;
public abstract class RogueClass : Player {
    public string ClassName { get; }
    public string Description { get; }
    protected int _selectedIndex;
    protected RogueClass(string name, string description, int hp, int str, int arm)
      : base(name, name)
    {
        ClassName = name;
        Description = description;

        _maxHp = hp;
        _hp = hp;
        _maxStr = str;
        _str = str;
        _arm = arm;
        Name = name;
    }
    private List<(string Name, int Count, string Description, char Glyph, ConsoleColor Color)> GetGroupedItems()
    {
        return Items
       .GroupBy(i => i.Name)
       .Select(g => (
           Name: g.Key,
           Count: g.Count(),
           Description: g.First().Description,
           Glyph: g.First().Glyph,
           Color: g.First().Color
       ))
       .ToList();
    }
    public override void Add(Item item)
    {
        if (item == null) return;
        _inventory.Add(item);
    }

    protected readonly Inventory _inventory = new Inventory();
    public bool Remove(Item item) => _inventory.Remove(item);
    public Inventory Inventory => _inventory;
    public IReadOnlyList<Item> Items => _inventory.Items;
    protected void FadeOutInventory(int start)
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
    public override void ShowInventory()
    {
        int start = 5;
        ConsoleKey key;
        var grouped = GetGroupedItems();
        var selected = grouped[_selectedIndex];
        do
        {
            DrawInventoryWindow(start);
            // find ONE matching item in real inventory
            var item = Items.FirstOrDefault(i => i.Name == selected.Name);
            if (item != null)
            {
                item.Use(this);// use it    
                Remove(item);// remove ONE instance
            }
            if (item == null)
            {
                Console.SetCursorPosition(0, 23);
                Console.Write("Item not found!");
                Console.ReadKey(true);
                return;
            }
            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && _selectedIndex > 0)
                _selectedIndex--;
            if (key == ConsoleKey.DownArrow && _selectedIndex < grouped.Count - 1)

            if (key == ConsoleKey.Enter && Items.Count > 0)
            {
                // Example action — you can expand this later
                Console.SetCursorPosition(0, start + 16);
                Console.WriteLine($"You selected: {grouped[_selectedIndex].Name}");
                item.Use(this);
                Remove(item);
                Console.ReadKey(true);
            }
              
        } while (key != ConsoleKey.Escape);
        FadeOutInventory(start);
    }
    protected void DrawInventoryWindow(int start)
    {

        for (int row = start; row <= start + 14; row++)
        {
            Console.SetCursorPosition(0, row);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        Console.SetCursorPosition(0, start);
        Console.WriteLine("┌──────────────────────────────────────────┐");
        Console.SetCursorPosition(0, start + 1);
        Console.WriteLine("│              === INVENTORY ===           │");
        Console.WriteLine("│                                          │");
        int line = start + 3;

        if (Items.Count == 0)
        {
            Console.SetCursorPosition(0, line);
            Console.WriteLine("│                 (empty)                  │");
            line++;
        }
        else
        {
            var grouped = Items
             .GroupBy(i => i.Name)
             .Select(g => new {
              Name = g.Key,
              Count = g.Count(),
              Description = g.First().Description,
              Glyph = g.First().Glyph,
              Color = g.First().Color
             })
      .ToList();

            for (int i = 0; i < grouped.Count; i++)
            {
                Console.SetCursorPosition(0, line);

                bool selected = (i == _selectedIndex);

                var item = grouped[i];

                // icon color
                if(selected)
                Console.ForegroundColor = item.Color;

                string icon = item.Glyph.ToString();

                // reset for text
                Console.ResetColor();

                Console.Write($"│ {(selected ? ">" : " ")} ");

                // draw icon
                Console.ForegroundColor = item.Color;
                Console.Write(icon);
                Console.ResetColor();

                // draw rest
                Console.WriteLine($" {item.Name} x{item.Count,-14} {item.Description,-19} │");

                Console.ResetColor();
                line++;
            }
        }

        while (line < start + 14)
        {
            Console.SetCursorPosition(0, line);
            Console.WriteLine("│                                          │");
            line++;
        }

        Console.SetCursorPosition(0, start + 14);
        Console.WriteLine("└──────────────────────────────────────────┘");

        Console.SetCursorPosition(0, start + 16);
        Console.WriteLine("Use ↑ ↓ to navigate, Enter to select, Esc to exit.");

    }

    public override string ToString() => $"{ClassName}: {Description} (HP:{_hp}, Str:{_str}, Arm:{_arm})";
}

// Concrete archetypes

//character classes with different stats and playstyles
public class Paladin : RogueClass {
    public Paladin() : base("Paladin", "skilled melee fighter. High HP and armour.", hp: 20, str: 18, arm: 6) { }
}

public class Rogue : RogueClass {
    public Rogue() : base("Rogue", "Fast and stealthy. Medium HP and locate items easiliy.", hp: 14, str: 14, arm: 3) { }
}

public class Wizard : RogueClass {
    public Wizard() : base("Wizard", "Fragile spellcaster. High damage potential.", hp: 12, str: 20, arm: 2) { }
}
public class Barbarian : RogueClass
{
    public Barbarian() : base("Barbarian", "Brute force fighter. High HP and strength, but low armour.", hp: 22, str: 22, arm: 1) { }
}
public class Archer : RogueClass
{
    public Archer() : base("Archer", "Ranged attacker. Medium HP and strength, but can attack from a distance.", hp: 16, str: 16, arm: 2) { }
}
// Simple factory / helper to list and create classes
public static class RogueFactory {
    public static string[] GetOptions() => new[] { "Paladin", "Rogue", "Wizard", "Barbarian", "Archer" };
    public static RogueClass Create(string option) {
        return option switch {
            "Barbarian" => new Barbarian(),
            "Paladin" => new Paladin(),
            "Rogue" => new Rogue(),
            "Wizard" => new Wizard(),
            "Archer" => new Archer(),
            _ => new Rogue(),
        };
    }
}
