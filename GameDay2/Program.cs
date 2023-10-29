using AdventGames.Data;
using AdventGames.Data.Models;
using Rock_Paper_Scissors;
using System.Numerics;

namespace GameDay2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Advent games day2 player!");
            Console.WriteLine();

            try
            {
                // Intialize 
                Referee referee = new Referee();
                BigInteger totalScore = 0;

                // Read data
                AdventGamesRepository repository = new AdventGamesRepository();
                List<RPSResult> data = repository.GetRPSResults(@"Data\Day2GameData.txt");

                // Sum scores
                foreach (var item in data)
                {
                    totalScore += referee.GetGameScorePlayer2(item.player1Input, item.player2Input);
                }

                // Present totalscore
                Console.WriteLine(string.Format("Totale score = {0}", totalScore));
            }
            catch (Exception ex)
            {
                Console.WriteLine("De volgende fout is opgetreden: {0}", ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Druk op een toets om het programma af te sluiten.");
            Console.ReadKey();
        }
    }
}