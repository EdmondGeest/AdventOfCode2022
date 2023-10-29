namespace Rock_Paper_Scissors
{
    public interface IGameStrategy
    {
        /// <summary>
        /// In de strategy wordt bepaalt welke keuze de speler
        /// als tegenzet doet.
        /// Hierbij kan de zet van tegenspeler ook gebruikt worden. 
        /// </summary>
        /// <param name="opponentChoice"></param>
        /// <param name="playerChoice"></param>
        /// <returns>de zet van speler 2</returns>
        string DetermineGameChoice(string opponentChoice, string playerChoice);
    }
}