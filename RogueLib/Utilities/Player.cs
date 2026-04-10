using RogueLib.Dungeon;
using RogueLib.Utilities;

public abstract class Player : IActor, IDrawable
{
    public string Name { get; set; }
    public Vector2 Pos;
    public char Glyph => '@';
    public ConsoleColor _color = ConsoleColor.White;

    protected int _level = 0;
    protected int _hp = 12;
    protected int _str = 16;
    protected int _arm = 4;
    protected int _exp = 0;
    protected int _gold = 0;
    protected int _maxHp = 12;
    protected int _maxStr = 16;
    protected int _turn = 0;

    public int Turn => _turn;

    // Inventory for the player
    public Inventory Inventory { get; } = new Inventory();

    public Player()
    {
        Name = "Rogue";
        Pos = Vector2.Zero;
    }

    public string HUD =>
       $"Level:{_level}  Gold: {_gold}    Hp: {_hp}({_maxHp})" +
       $"  Str: {_str}({_maxStr})" +
       $"  Arm: {_arm}   Exp: {_exp}/{10} Turn: {_turn}";

    public void AddGold(int amount)
    {
        if (amount <= 0) return;
        _gold += amount;
    }
    public virtual void Update()
    {
        _turn++;
    }
    public virtual void Draw(IRenderWindow disp)
    {
        disp.Draw(Glyph, Pos, _color);
    }
    public void TakeDamage(int damage)
    {
        int effectiveDamage = Math.Max(0, damage - _arm);
        _hp -= effectiveDamage;
        if (_hp <= 0)
        {
            _hp = 0;
            // Handle player death (e.g., trigger game over)
        }
    }
}