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
            Console.WriteLine("\n" +
                "Dit programma berekent de totale score van een aantal wedstrijden\n" +
                "Rock Paper Scissors op basis van een spel strategie\n" +
                "\n" +
                "De wedstrijdresultaten staan in een bestand wat bij deze code wordt meegeleverd.\n" +
                "Zie Data\\Day2Gamedata.txt\n" +
                "\n" +
                "Er kan een spel strategy gekozen worden door op de commandline\n" +
                "een 1 of een 2 in te voeren:\n" +
                "Gameday2 <gamestrategy>\n" +
                "Zonder keuze wordt strategy 1 gebruikt.\n" +
                "\n" +
                "Het resultaat kan ingevoerd worden op https://adventofcode.com/2022/day/2" +
                "\n");

            try
            {
                // Initialize                
                // Default the firstgamestrategy is selected.
                IGameStrategy gameStrategy = DeterminegameStrategy(args);
                Referee referee = new Referee(gameStrategy);
                BigInteger totalScore = 0;

                // Read data
                AdventGamesRepository repository = new AdventGamesRepository();
                List<RPSGameRecord> data = repository.GetRPSRecords(@"Data\Day2GameData.txt");

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

        private static IGameStrategy DeterminegameStrategy(string[] args)
        {
            IGameStrategy gameStrategy = new FirstGameStrategy();
            if (args.Length > 0)
            {
                if (args[0].Equals("1"))
                    gameStrategy = new FirstGameStrategy();
                if (args[0].Equals("2"))
                    gameStrategy = new SecondGameStrategy();
            }

            return gameStrategy;
        }
    }
}