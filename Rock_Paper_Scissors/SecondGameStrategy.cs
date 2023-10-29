using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class SecondGameStrategy : IGameStrategy
    {
        public string DetermineGameChoice(string player1Choice, string player2Choice)
        {
            string choicePlayer1 = player1Choice.ToLower();
            string choicePlayer2 = player2Choice.ToLower();

            switch (choicePlayer2)
            {
                case "y": // Draw
                    switch (choicePlayer1)
                    {
                        case "a": return "a";
                        case "b": return "b";
                        case "c": return "c";
                        default:
                            break;
                    }
                    break;
                case "x": // Lose
                    switch (choicePlayer1)
                    {
                        case "a": return "c";
                        case "b": return "a";
                        case "c": return "b";
                        default:
                            break;
                    }
                    break;
                case "z": // Win
                    switch (choicePlayer1)
                    {
                        case "a": return "b";
                        case "b": return "c";
                        case "c": return "a";
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return player1Choice;
        }
    }
}
