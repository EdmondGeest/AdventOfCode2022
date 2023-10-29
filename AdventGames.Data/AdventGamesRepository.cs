using AdventGames.Data.Models;

namespace AdventGames.Data
{
    /// <summary>
    /// Deze class bevat de functies voor toegang tot de data van de verschillende games. 
    /// </summary>
    public class AdventGamesRepository
    {
        /// <summary>
        /// Deze functie leest de rock paper scissors gegevens in uit een tekst bestand 
        /// en levert vervolgens een lijst met wedstrijdresultaten.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Wedstrijdresultaten</returns>
        public List<RPSResult> GetRPSResults(string fileName)
        {
            List<RPSResult> result = new List<RPSResult>();

            IEnumerable<string> rpsGameResults = File.ReadLines(fileName);
            foreach (string psGameResult in rpsGameResults)
            {
                string[] gameResult = psGameResult.Split(new char[] { ' ', });
                RPSResult rpsResult = RPSResult.Create(gameResult[0], gameResult[1]);
                result.Add(rpsResult);
            }

            return result;
        }

        /// <summary>
        /// Deze functie leest de snafu nummers in uit een tekst bestand 
        /// en levert vervolgens een lijst met snafu nummers
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Lijst met snafu nummers</returns>
        public List<SnafuNumber> GetSnafuNumbers(string fileName)
        {
            List<SnafuNumber> result = new List<SnafuNumber>();

            IEnumerable<string> snafuNumbers = File.ReadLines(fileName);
            foreach(string number in snafuNumbers)
            {
                SnafuNumber snafuNumber = SnafuNumber.Create(number);
                result.Add(snafuNumber);
            }

            return result;
        }
    }
}