using System;
using System.Reflection.Metadata.Ecma335;
using System.Security;

namespace PlayerStats
{
    public class Player
    {
        public float highScore;
        public int playedGames;
        public int wonGames;
        public string playerName;

        public Player(string name)
        {
            playerName = name;
            wonGames = 0;
            playedGames = 0;
            highScore = 0.0f;
        }

        public float HighScore
        {
            get
            {
                return highScore;
            }
            set
            {
                if (value > highScore)
                {
                    highScore = value;
                }
            }
        }

        public string Name
        {
            get { return playerName; }
        }

        public float WinRate
        {
            get { return wonGames == 0 ? 0 : (float)wonGames / playedGames; }
        }

        public void PlayGame(bool win)
        {
            playedGames++;
            if (win)
            {
                wonGames++;
            }
        }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            Player[] players = {
                new Player("Ana"),
                new Player("Zé"),
                new Player("Doesn't play")
            };

            players[0].PlayGame(false);
            players[0].PlayGame(true);
            players[0].PlayGame(true);
            players[0].PlayGame(false);
            players[0].PlayGame(false);
            players[0].PlayGame(true);
            players[0].HighScore = 123;
            players[0].HighScore = 40;

            players[1].PlayGame(true);
            players[1].PlayGame(true);
            players[1].HighScore = 12;
            players[1].HighScore = 67;
            players[1].HighScore = 91;
            players[1].HighScore = 32;

            foreach (Player player in players)
            {
                Console.WriteLine($" Player name : {player.Name}");
                Console.WriteLine($"    Win rate : {player.WinRate}");
                Console.WriteLine($"  High score : {player.HighScore}");
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
