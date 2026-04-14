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
    private char glyph;
    public ConsoleColor Color => _color;
    protected Item(Vector2 pos, char glyph, ConsoleColor color)
    {
        Pos = pos;
        _glyph = glyph;
        _color = color;
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
        disp.Draw(Glyph, Pos, _color);
    }
}
