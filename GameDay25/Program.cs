using AdventGames.Data;
using AdventGames.Data.Models;
using Full_Of_Hot_Air;
using System.Numerics;

namespace GameDay25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Advent games day25 player!");
            Console.WriteLine("\n" +
                "Dit programma berekent het SNAFU nummer dat moet worden \n" +
                "ingevoerd in Bob's console.\n" +
                "\n" +
                "De snafu nummers van de vaten staan in een bestand wat bij deze code wordt meegeleverd.\n" +
                "Zie Data\\Day25Gamedata.txt\n" +
                "\n" +
                "Het resultaat kan ingevoerd worden op https://adventofcode.com/2022/day/25" +
                "\n");

            try
            {
                // Initialize
                SNAFUNumberConvertor convertor = new SNAFUNumberConvertor();
                Decimal result = 0;

                // Read data
                AdventGamesRepository repository = new AdventGamesRepository();
                List<SnafuNumberRecord> snafuNumbers = repository.GetSnafuNumberRecords(@"Data\Day25GameData.txt");

                // Convert items to decimals and sum up
                foreach (var number in snafuNumbers)
                {
                    result += convertor.ConvertSnafuNumberToDecimal(number.Number);
                }

                // Convert sum of bigint to snafunumber
                String snafuNumber = convertor.ConvertDecimalToSnafuNumber(result);

                // Present snafunumber
                Console.WriteLine(string.Format("Het SNAFU nummer is {0}", snafuNumber));
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