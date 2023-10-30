using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class Part1GameStrategy : IGameStrategy
    {
        public static Part1GameStrategy Create()
        {
            return new Part1GameStrategy();
        }

        public string DeterminePlayerChoice(string opponentChoice, string playerStrategyChoice)
        {
            var strategyChoice = playerStrategyChoice.ToLower();
            switch (strategyChoice)
            {
                case "x": return "a";
                case "y": return "b";
                case "z": return "c";
                default:
                    break;
            }
            return string.Empty;
        }
    }
}
