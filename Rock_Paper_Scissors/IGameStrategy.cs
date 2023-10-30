namespace Rock_Paper_Scissors
{
    public interface IGameStrategy
    {
        /// <summary>
        /// In de strategy wordt bepaalt welke keuze de speler
        /// als tegenzet doet.
        /// Hierbij kan de zet van de opponent ook gebruikt worden. 
        /// </summary>
        /// <param name="opponentChoice"></param>
        /// <param name="playerStrategyChoice"></param>
        /// <returns>de zet van de speler</returns>
        string DeterminePlayerChoice(string opponentChoice, string playerStrategyChoice);
    }
}