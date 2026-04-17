using RogueLib.Utilities;
using System;

namespace RogueLib.enemies
{
    public class Boss : NPC
    {
        private static bool bossExists = false;

        private int attackCooldown;
        private bool enraged = false;

        public int MaxHP { get; private set; }

        private static readonly string[] Taunts =
        {
            "You dare challenge me?",
            "Your journey ends here.",
            "I will crush you.",
            "Your fate is sealed!"
        };

        public Boss(Vector2 pos, string name = "Bob", int health = 100)
            : base(pos, name, 'Ω', ConsoleColor.DarkRed, health, 5)
        {
            if (bossExists)
                throw new Exception("A Boss already exists in this level!");

            bossExists = true;
            MaxHP = health;
            attackCooldown = 0;

            Console.WriteLine($"⚠ A powerful presence emerges... {Name} has appeared!");
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);

            if (!enraged && HP <= MaxHP / 2)
            {
                enraged = true;
                Damage += 2;
                Console.WriteLine($"{Name} becomes enraged!");
            }

            if (HP <= 0)
            {
                // Prevent double-death
                if (bossExists)
                {
                    bossExists = false;
                    Die();
                }
            }
        }

        public override void Die()
        {
            if (PlayerRef != null)
            {
                PlayerRef.Exp += 50;
                Console.WriteLine("*** THE BOSS COLLAPSES IN A BURST OF DARK ENERGY ***");
            }

            bossExists = false;
            base.Die();
        }

        public override void Update()
        {
            if (PlayerRef == null)
                return;

            if (attackCooldown > 0)
                attackCooldown--;

            var dist = (PlayerRef.Pos - Pos).Length;

            if (dist == 1 && attackCooldown == 0)
            {
                PlayerRef.TakeDamage(3);
                attackCooldown = 10;
                return;
            }

            if (dist == 2 && attackCooldown == 0)
            {
                Console.WriteLine($"{Name} lunges at you!");
                PlayerRef.TakeDamage(2);
                attackCooldown = 12;
                return;
            }
            Random Rng = new Random();
            // Optional: boss taunts occasionally
            if (Rng.Next(0, 20) == 0)
                Console.WriteLine($"{Name}: {Taunts[Rng.Next(Taunts.Length)]}");
        }
    }
}
