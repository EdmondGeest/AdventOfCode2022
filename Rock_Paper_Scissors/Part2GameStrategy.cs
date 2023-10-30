using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class Part2GameStrategy : IGameStrategy
    {
        private const string Rock = "a";
        private const string Paper = "b";
        private const string Scissors = "c";

        public static Part2GameStrategy Create()
        {
            return new Part2GameStrategy();
        }

        public string DeterminePlayerChoice(string opponentChoice, string playerStrategyChoice)
        {
            string choiceOpponent = opponentChoice.ToLower();
            string strategyChoice = playerStrategyChoice.ToLower();

            switch (strategyChoice)
            {
                case "y": // Draw
                    switch (choiceOpponent)
                    {
                        case Rock: return Rock;
                        case Paper: return Paper;
                        case Scissors: return Scissors;
                        default:
                            break;
                    }
                    break;
                case "x": // Lose
                    switch (choiceOpponent)
                    {
                        case Rock: return Scissors;
                        case Paper: return Rock;
                        case Scissors: return Paper;
                        default:
                            break;
                    }
                    break;
                case "z": // Win
                    switch (choiceOpponent)
                    {
                        case Rock: return Paper;
                        case Paper: return Scissors;
                        case Scissors: return Rock;
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
