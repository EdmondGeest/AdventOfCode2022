using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class FirstGameStrategy : IGameStrategy
    {
        public string DetermineGameChoice(string player1Choice, string player2Choice)
        {
            var choice = player2Choice.ToLower();
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
