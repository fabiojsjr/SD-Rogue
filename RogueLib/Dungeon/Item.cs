using RogueLib.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RogueLib.Dungeon;

public abstract class Item : IDrawable {

    public Vector2 Pos { get; set; }
    public string Glyph { get; }

    protected char _glyph;
    protected ConsoleColor _color;
    private char glyph;
    private string v;

    public ConsoleColor Color => _color;
    protected Item(Vector2 pos, char glyph, ConsoleColor color)
    {
        Pos = pos;
        _glyph = glyph;
        _color = color;
    }

    protected Item(Vector2 pos, string v, ConsoleColor color)
    {
        Pos = pos;
        V1 = v;
        Color1 = color;
    }

    protected Item(Vector2 pos, string v)
    {
        Pos = pos;
        this.v = v;
    }

    public virtual void Use(Player player)
    {
        // default: do nothing
    }

    public virtual string Name => GetType().Name;
    public virtual string Description => string.Empty;

    public char V { get; }
    public System.Numerics.Vector2 Pos1 { get; }
    public ConsoleColor Green { get; }
    public string V1 { get; }
    public ConsoleColor Color1 { get; }

    public class ItemDTO {
        public string Type { get; set; } = "";
        public int Amount { get; set; }
    }
    public virtual ItemDTO ToDTO() => new ItemDTO { Type = GetType().Name };
    public static Item? FromDTO(ItemDTO dto)
    {
        return dto.Type switch
        {
            _ => null,
        };
    }

    public virtual void Draw(IRenderWindow disp) {
        var s = Glyph;

        if (s == null)
        {
            Console.SetCursorPosition(0, 22);
            Console.WriteLine($"[DEBUG] Null glyph on item type: {GetType().Name}, Name: {Name}");
            s = "?"; // fallback so it doesn't crash
        }

        disp.Draw(s, Pos, Color);
    }
}
