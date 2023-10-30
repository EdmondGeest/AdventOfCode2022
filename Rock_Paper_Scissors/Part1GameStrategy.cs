using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class Part1GameStrategy : IGameStrategy
    {
        private const string Rock = "a";
        private const string Paper = "b";
        private const string Scissors = "c";

        public static Part1GameStrategy Create()
        {
            return new Part1GameStrategy();
        }

        public string DeterminePlayerChoice(string opponentChoice, string playerStrategyChoice)
        {
            var strategyChoice = playerStrategyChoice.ToLower();
            switch (strategyChoice)
            {
                case "x": return Rock;
                case "y": return Paper;
                case "z": return Scissors;
                default:
                    break;
            }
            return string.Empty;
        }
    }
}
