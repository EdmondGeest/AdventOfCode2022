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
        public List<RPSStrategyRecord> GetRPSStrategyGuide(string fileName)
        {
            List<RPSStrategyRecord> result = new List<RPSStrategyRecord>();

            IEnumerable<string> rpsStrategyRecords = File.ReadLines(fileName);
            foreach (string record in rpsStrategyRecords)
            {
                string[] strategyRecordFields = record.Split(new char[] { ' ', });
                RPSStrategyRecord rpsStrategyRecord = RPSStrategyRecord.Create(strategyRecordFields[0], strategyRecordFields[1]);
                result.Add(rpsStrategyRecord);
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