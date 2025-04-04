using System;
using System.Data;
using System.Xml.XPath;

namespace MyRPG
{
    public class Program
    {
        public class Player
        {
            public string playerName;
            public int level;
            private int Xp;
            private float health;
            public float maxHealth;

            public Player(string name)
            {
                playerName = name;
                Xp = 0;
                health = maxHealth;
            }

            public string Name
            {
                get { return playerName; }
            }

            public void XP(int xp)
            {
                Xp ++;
                Xp = xp;
            }

            public int Level
            {
                get
                {
                    level = 1 + Xp / 1000;
                    return level;
                }

            }

            public float Health()
            {
                if (health > 0 && health <= maxHealth)
                {
                    health = maxHealth;
                }
                return health;
            }

            public float MaxHealth
            {
                get
                {
                    maxHealth = 100 + (Level - 1) * 20;
                    return maxHealth;
                }
            }

            public void TakeDamage(float damage)
            {
                Xp = (int)damage / 20;
                health += damage;
            }
        }
        private static void Main()
        {
            Player player = new Player("Hero");

            Console.WriteLine($"Name: {player.Name}");      // Name: Hero
            Console.WriteLine($"Level: {player.Level}");    // Level: 1
            Console.WriteLine($"XP: {player.XP}");          // XP: 0
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}"); // Health: 100/100

            player.XP = 2500; // Aumenta XP para 2500
            Console.WriteLine($"Level: {player.Level}");    // Level: 3
            Console.WriteLine($"XP: {player.XP}");          // XP: 2500
            Console.WriteLine($"MaxHealth: {player.MaxHealth}"); // MaxHealth: 140

            player.TakeDamage(45);
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}"); // Health: 55/140
            Console.WriteLine($"XP: {player.XP}");          // XP: 2502
            Console.WriteLine($"Level: {player.Level}");    // Level: 3

            player.Health = -10;  // Tentativa de colocar health negativa
            Console.WriteLine($"Health: {player.maxHealth}");  // Health: 0

            player.Health = 5000; // Tentativa de ultrapassar maxHealth
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}"); // Health: 140/140

            // Output esperado:
            //
            // Name: Hero
            // Level: 1
            // XP: 0
            // Health: 100/100
            // Level: 3
            // XP: 2500
            // MaxHealth: 140
            // Health: 55/140
            // XP: 2502
            // Level: 3
            // Health: 0
            // Health: 140/140
        }
    }
}
