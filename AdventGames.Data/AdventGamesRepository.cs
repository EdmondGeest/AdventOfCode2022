using AdventGames.Data.Models;

namespace AdventGames.Data
{
    /// <summary>
    /// Deze class bevat de functies voor toegang tot de data van de verschillende games. 
    /// </summary>
    public class AdventGamesRepository
    {
        public static AdventGamesRepository Create()
        {
            return new AdventGamesRepository();
        }

        /// <summary>
        /// Deze functie leest de rock paper scissors gegevens in uit een tekst bestand 
        /// en levert vervolgens een lijst met wedstrijdresultaten.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Wedstrijdresultaten</returns>
        public List<RPSGameRecord> GetRPSRecords(string fileName)
        {
            List<RPSGameRecord> result = new List<RPSGameRecord>();

            IEnumerable<string> rpsGameRecords = File.ReadLines(fileName);
            foreach (string psGameResult in rpsGameRecords)
            {
                string[] gameRecord = psGameResult.Split(new char[] { ' ', });
                RPSGameRecord rpsRecord = RPSGameRecord.Create(gameRecord[0], gameRecord[1]);
                result.Add(rpsRecord);
            }

            return result;
        }

        /// <summary>
        /// Deze functie leest de snafu nummers in uit een tekst bestand 
        /// en levert vervolgens een lijst met snafu nummers
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Lijst met snafu nummers</returns>
        public List<SnafuNumberRecord> GetSnafuNumberRecords(string fileName)
        {
            List<SnafuNumberRecord> result = new List<SnafuNumberRecord>();

            IEnumerable<string> snafuNumberRecords = File.ReadLines(fileName);
            foreach(string numberRecord in snafuNumberRecords)
            {
                SnafuNumberRecord snafuNumberRecord = SnafuNumberRecord.Create(numberRecord);
                result.Add(snafuNumberRecord);
            }

            return result;
        }
    }
}