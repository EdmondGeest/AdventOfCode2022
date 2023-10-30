using AdventGames.Data;
using AdventGames.Data.Models;
using Rock_Paper_Scissors;
using System.Dynamic;
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
                "De strategie data staat in een bestand wat bij deze code wordt meegeleverd\n" +
                "Zie Data\\Day2Gamedata.txt\n" +
                "\n" +
                "Er zijn 2 spel strategieen:\n" +
                "een strategie voor part 1 en een strategie voor part 2\n" +
                "De strategieen worden na elkaar toegepast op dezelfde strategie data\n" +
                "\n" +
                "Het resultaat kan ingevoerd worden op https://adventofcode.com/2022/day/2" +
                "\n");

            try
            {
                // Initialize                

                // De referee is de scheidsrechter die de regels kent en de score bepaalt
                Referee referee = Referee.Create();

                // Read strategyRecords
                AdventGamesRepository repository = AdventGamesRepository.Create();
                List<RPSStrategyRecord> strategyRecords = repository.GetRPSStrategyGuide(@"Data\Day2GameData.txt");

                // loop through strategies and show totalscore
                for (int i = 1; i <= 2; i++)
                {
                    // Init strategy en totalscore
                    IGameStrategy gameStrategy = SelectGameStrategy(i);
                    BigInteger totalScore = 0;

                    // Sum scores
                    foreach (var strategyRecord in strategyRecords)
                    {
                        string playerChoice = gameStrategy.DeterminePlayerChoice(strategyRecord.opponentChoice, strategyRecord.playerStrategyChoice);
                        if (referee.PlayerChoicesAreValid(strategyRecord.opponentChoice, playerChoice))
                            totalScore += referee.GetGameScorePlayer(strategyRecord.opponentChoice, playerChoice);
                        else
                            throw new ArgumentException(string.Format("Onjuiste invoer gevonden in dataset: {0}, {1}", strategyRecord.opponentChoice, playerChoice));
                    }

                    // Present totalscore
                    Console.WriteLine(string.Format("Totale score volgens strategie van part {0} = {1}", i, totalScore));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("De volgende fout is opgetreden: {0}", ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Druk op een toets om het programma af te sluiten");
            Console.ReadKey();
        }

        private static IGameStrategy SelectGameStrategy(int partNumber)
        {
            switch (partNumber)
            {
                case 1:
                    Console.WriteLine("Strategie geselecteerd van part 1");
                    return Part1GameStrategy.Create();
                case 2:
                    Console.WriteLine("Strategie geselecteerd van part 2");
                    return Part2GameStrategy.Create();
            }
            throw new ArgumentException(string.Format("Onbekend part nummer: {0}", partNumber));
        }
    }
}