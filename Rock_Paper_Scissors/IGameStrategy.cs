namespace Rock_Paper_Scissors
{
    public interface IGameStrategy
    {
        string DetermineGameChoice(string player1Choice, string player2Choice);
    }
}