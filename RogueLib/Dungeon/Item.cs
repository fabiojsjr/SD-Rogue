using RogueLib.Utilities;
using System;

namespace RogueLib.Dungeon;

public abstract class Item : IDrawable
{
    public Vector2 Pos { get; set; }

    // The actual glyph used for drawing
    public string Glyph { get; }

    protected char _glyph;
    protected ConsoleColor _color;

    public ConsoleColor Color => _color;

    // --- VALID CONSTRUCTORS ---

    // 1) Char‑based glyph
    protected Item(Vector2 pos, char glyph, ConsoleColor color)
    {
        Pos = pos;
        _glyph = glyph;
        _color = color;
        Glyph = glyph.ToString();
    }

    // 2) String‑based glyph
    protected Item(Vector2 pos, string glyph, ConsoleColor color)
    {
        Pos = pos;
        Glyph = glyph;
        _color = color;
    }

    // --- DEFAULT BEHAVIOR ---

    public virtual void Use(Player player)
    {
        // default: do nothing
    }

    public virtual string Name => GetType().Name;
    public virtual string Description => string.Empty;

    // --- DTO SUPPORT ---

    public class ItemDTO
    {
        public string Type { get; set; } = "";
        public int Amount { get; set; }
    }

    public virtual ItemDTO ToDTO() =>
        new ItemDTO { Type = GetType().Name };

    public static Item? FromDTO(ItemDTO dto)
    {
        return dto.Type switch
        {
            _ => null,
        };
    }

    // --- DRAWING ---

    public virtual void Draw(IRenderWindow disp)
    {
        disp.Draw(Glyph, Pos, Color);
    }
}
