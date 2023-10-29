using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class FirstGameStrategy : IGameStrategy
    {
        public string DetermineGameChoice(string opponentChoice, string playerChoice)
        {
            var choice = playerChoice.ToLower();
            switch (choice)
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
