using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class SecondGameStrategy : IGameStrategy
    {
        public string DetermineGameChoice(string opponentChoice, string playerChoice)
        {
            string choiceOpponent = opponentChoice.ToLower();
            string choicePlayer = playerChoice.ToLower();

            switch (choicePlayer)
            {
                case "y": // Draw
                    switch (choiceOpponent)
                    {
                        case "a": return "a";
                        case "b": return "b";
                        case "c": return "c";
                        default:
                            break;
                    }
                    break;
                case "x": // Lose
                    switch (choiceOpponent)
                    {
                        case "a": return "c";
                        case "b": return "a";
                        case "c": return "b";
                        default:
                            break;
                    }
                    break;
                case "z": // Win
                    switch (choiceOpponent)
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
            return opponentChoice;
        }
    }
}
