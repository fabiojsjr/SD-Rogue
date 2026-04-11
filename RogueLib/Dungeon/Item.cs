using RogueLib.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RogueLib.Dungeon;

public abstract class Item : IDrawable {

    public Vector2 Pos { get; set; }
    public char Glyph => _glyph;

    protected char _glyph;
    protected ConsoleColor _color;

    public Item(char gly, Vector2 pos, ConsoleColor color = ConsoleColor.Yellow) {
        _color = color;
        _glyph = gly;
        Pos = pos;
    }

    protected Item(string gold, string xp, Vector2 pos = default)
    {
        Pos = pos;
    }

    protected Item(char gly, string xp, Vector2 pos, ConsoleColor color = ConsoleColor.Green) 
    {
        _color = color;
        _glyph = gly;
        Pos = pos;
    }

    protected Item(char v, System.Numerics.Vector2 pos, ConsoleColor green)
    {
        V = v;
        Pos1 = pos;
        Green = green;
    }

    public virtual string Name => GetType().Name;
    public virtual string Description => string.Empty;

    public char V { get; }
    public System.Numerics.Vector2 Pos1 { get; }
    public ConsoleColor Green { get; }

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

    public void Draw(IRenderWindow disp) {
        disp.Draw(_glyph, Pos, _color);
    }
}
