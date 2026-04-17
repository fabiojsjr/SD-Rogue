using RogueLib.Utilities;

namespace RogueLib.enemies
{
    internal class Boss : NPC
    {
        private static bool bossExists = false;   // NEW: ensures only one boss
        private int attackCooldown;
        private bool enraged = false;

        public string name { get; set; } = "Bob";
        public int MaxHP { get; private set; } = 100;

        public Boss(Vector2 pos, string name, int health)
            : base(pos, name, 'Ω', ConsoleColor.DarkRed, health, 5)
        {
            Console.WriteLine($"⚠ A powerful presence emerges... {name} has appeared!");
            if (bossExists)
            {
                // Prevent a second boss from spawning
                throw new Exception("A Boss already exists in this level!");
            }

            bossExists = true;
            attackCooldown = 0;
        }
        private static readonly string[] Taunts =
        {
                "You dare challenge me?",
                "Your journey ends here.",
                "I will crush you.",
                "Your fate is sealed!"
        };

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            if (!enraged && HP <= (MaxHP / 2))
            {
                enraged = true;
                Damage += 2;
                Console.WriteLine($"{Name} becomes enraged!");
            }
            if (HP <= 0)
            {
                Die();
            }
        }

        public override void Die()
        {
            // Boss EXP reward
            if (PlayerRef != null)
            {
                PlayerRef.Exp += 50;
                Console.WriteLine("*** THE BOSS COLLAPSES IN A BURST OF DARK ENERGY ***");
            }

            bossExists = false; // allow a new boss in future levels
            base.Die();
        }

        public override void Update()
        {
            if (attackCooldown > 0)
            {
                attackCooldown--;
            }

            if ((PlayerRef.Pos - Pos).Length == 1 && attackCooldown == 0)
            {
                PlayerRef.TakeDamage(3);
                attackCooldown = 10;
                return;
            }
            if ((PlayerRef.Pos - Pos).Length == 2 && attackCooldown == 0)
            {
                Console.WriteLine($"{Name} lunges at you!");
                PlayerRef.TakeDamage(2);
                attackCooldown = 12;
                return;
            }
        }
    }
}
/* this is added to level.cs
 public static bool BossDefeated { get; private set; } = false;
BossDefeated = true;
if (Boss.BossDefeated) {  spawn loot }

 
 
 
 */