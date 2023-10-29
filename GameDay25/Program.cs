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
            Console.WriteLine();

            try
            {
                // Initialize
                SNAFUNumberConvertor convertor = new SNAFUNumberConvertor();
                Decimal result = 0;

                // Read data
                AdventGamesRepository repository = new AdventGamesRepository();
                List<SnafuNumber> snafuNumbers = repository.GetSnafuNumbers(@"Data\Day25GameData.txt");

                // Convert items to decimals and sum up
                foreach (var number in snafuNumbers)
                {
                    result += convertor.ConvertSnafuNumberToDecimal(number.Number);
                }

                // Convert sum of bigint to snafunumber
                String snafuNumber = convertor.ConvertDecimalToSnafuNumber(result);

                // Present snafunumber
                Console.WriteLine(string.Format("The SnafuNumber is {0}", snafuNumber));
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